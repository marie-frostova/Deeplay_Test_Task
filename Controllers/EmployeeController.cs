using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using Deeplay_EnterprisePersonnelAccounting.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deeplay_EnterprisePersonnelAccounting.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeService employeeService;
        public IPositionService positionService;
        public ISubdivisionService subdivisionService;
        public DBContext db;

        public EmployeeController(DBContext db)
        {
            this.db = db;
            employeeService = new EmployeeService(db);
            positionService = new PositionService(db);
            subdivisionService = new SubdivisionService(db);
        }

        /// <summary>
        /// Fill fields which are not in database
        /// </summary>
        /// <param name="employee"></param>
        private void FillEmplpyeeInfo(Employee employee)
        {
            employee.Subdivision = subdivisionService.GetSubdivisionById(employee.SubdivisionId).Result;
            employee.Position = positionService.GetPositionById(employee.PositionId).Result;
            employee.Subordinates = employeeService.GetSubordinatesById(employee.Id).Result;
        }

        /// <summary>
        /// Searches the database for users by request, by default the request is an empty string
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IActionResult Search(SearchQuery query)
        {
            query.SubdivisionId = subdivisionService.GetSubdivisionIdByName(query.Subdivision);
            query.PositionId = positionService.GetPositionIdByName(query.Position);

            employeeService.Search(query);
            foreach (var employee in query.Result)
                FillEmplpyeeInfo(employee);

            return View(query);
        }

        /// <summary>
        /// View an employee's profile
        /// </summary>
        /// <returns></returns>
        public IActionResult Employee([FromQuery] string strId)
        {
            var employee = strId == null ? null : employeeService.GetEmployeeById(Guid.Parse(strId)).Result;
            if (employee != null)
                FillEmplpyeeInfo(employee);
            return View(employee);
        }

        /// <summary>
        /// Edit employee's data
        /// </summary>
        /// <returns></returns>
        public IActionResult EditEmployee([FromQuery] string strId = "")
        {
            Employee employee;
            var positions = positionService.GetAllPositions().Result;
            var subdivisions = subdivisionService.GetAllSubdivisions().Result;
            if (strId != "")
            {
                employee = employeeService.GetEmployeeById(Guid.Parse(strId)).Result;
            }
            else
            {
                employee = new Employee();
            }
            return View(new EmployeeEditModel()
            {
                Employee = employee,
                Positions = positions,
                Subdivisions = subdivisions
            });
        }

        /// <summary>
        /// Add new employee or update
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrUpdateEmployee(Employee employee)
        {
            employeeService.AddOrUpdateEmployee(employee);
            return Redirect("/Employee/Employee?strId=" + employee.Id.ToString());
        }

        /// <summary>
        /// Remove employee
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteEmployee([FromQuery] string strId)
        {
            employeeService.DeleteEmployee(Guid.Parse(strId));
            return Redirect("/");
        }

        /// <summary>
        /// Helps to search appropriate candidates in ajax search form by partial input
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public IActionResult SearchEmployeeByRequisites([FromQuery] string queryStr)
        {
            var employees = employeeService.Search(queryStr);
            return View(employees);
        }
    }
}
