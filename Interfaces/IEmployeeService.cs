using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Helps to search appropriate candidates in ajax search form by partial input
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<Employee> Search(string queryStr);

        /// <summary>
        /// Searches the database for users by SearchQuery
        /// </summary>
        /// <param name="query"></param>
        public void Search(SearchQuery query);

        /// <summary>
        /// Add employee to database or update existing
        /// </summary>
        /// <param name="modifiedEmployee"></param>
        public void AddOrUpdateEmployee(Employee modifiedEmployee);

        /// <summary>
        /// Remove employee from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(Guid id);

        /// <summary>
        /// Search database for employee with Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Employee> GetEmployeeById(Guid Id);

        /// <summary>
        /// Search database for employees whose manager has Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<Employee>> GetSubordinatesById(Guid id);
    }
}
