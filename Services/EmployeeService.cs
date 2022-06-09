using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Services
{
    public class EmployeeService : IEmployeeService
    {
        private DBContext db;

        public EmployeeService(DBContext db)
        {
            this.db = db;
        }

        private void ProcessRequest(SearchQuery query)
        {
            if (query.Name != null)
                query.Name = query.Name.Trim();
            if (query.Surname != null)
                query.Surname = query.Surname.Trim();
            if (query.Patronymic != null)
                query.Patronymic = query.Patronymic.Trim();
        }

        public List<Employee> Search(string queryStr)
        {
            IQueryable<Employee> employees = db.Employees;
            var requisites = queryStr.Split();
            if (requisites.Length == 1)
            {
                employees = employees.Where(x => x.Surname.StartsWith(requisites[0]));
            }
            else if (requisites.Length == 2)
            {
                employees = employees.Where(x => x.Surname == requisites[0] && x.Name.StartsWith(requisites[1]));
            }
            else
            {
                employees = employees.Where(x => x.Surname == requisites[0] && x.Name == requisites[1] && x.Patronymic.StartsWith(requisites[2]));
            }
            return employees.Take(5).ToList();
        }

        public void Search(SearchQuery query)
        {
            ProcessRequest(query);
            FindMatchingEmployees(query);
        }

        private void FindMatchingEmployees(SearchQuery query)
        {
            IQueryable<Employee> employees = db.Employees;
            if (query.Name != null)
                employees = employees.Where(x => x.Name == query.Name);
            if (query.Surname != null)
                employees = employees.Where(x => x.Surname == query.Surname);
            if (query.Patronymic != null)
                employees = employees.Where(x => x.Patronymic == query.Patronymic);
            if (query.PositionId != new Guid())
                employees = employees.Where(x => x.PositionId == query.PositionId);
            if (query.SubdivisionId != new Guid())
                employees = employees.Where(x => x.SubdivisionId == query.SubdivisionId);

            query.ResultCount = employees.Count();
            employees = employees.Skip(query.Page * query.ResultsPerPage).Take(query.ResultsPerPage);
            query.Result = employees.ToList();
        }

        public void AddOrUpdateEmployee(Employee modifiedEmployee)
        {
            var employee = db.Employees.FirstOrDefault(p => modifiedEmployee.Id == p.Id);
            if (employee == null)
            {
                db.Employees.Add(modifiedEmployee);
            }
            else
            {
                employee.Name = modifiedEmployee.Name;
                employee.Surname = modifiedEmployee.Surname;
                employee.Patronymic = modifiedEmployee.Patronymic;
                employee.BirthDate = modifiedEmployee.BirthDate;
                employee.Sex = modifiedEmployee.Sex;
                employee.PositionId = modifiedEmployee.PositionId;
                employee.SubdivisionId = modifiedEmployee.SubdivisionId;
                employee.LineManagerId = modifiedEmployee.LineManagerId;
            }
            db.SaveChanges();
        }

        public void DeleteEmployee(Guid id)
        {
            db.Employees.Remove(GetEmployeeById(id).Result);
            db.SaveChanges();
        }

        public Task<Employee> GetEmployeeById(Guid Id)
        {
            var res = db.Employees.FirstOrDefault(e => e.Id == Id);
            if (res != null)
                res.LineManager = db.Employees.FirstOrDefault(e => e.Id == res.LineManagerId);
            return Task.FromResult(res);
        }

        public Task<List<Employee>> GetSubordinatesById(Guid id)
        {
            var subordinates = db.Employees.Where(e => e.LineManagerId == id).ToList();
            return Task.FromResult(subordinates);
        }
    }
}
