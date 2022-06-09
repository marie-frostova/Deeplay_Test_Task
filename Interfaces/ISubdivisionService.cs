using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Interfaces
{
    public interface ISubdivisionService
    {
        /// <summary>
        /// Gets all subdivisions from database
        /// </summary>
        /// <returns></returns>
        public Task<List<Subdivision>> GetAllSubdivisions();

        /// <summary>
        /// Gets subdivision from database by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Subdivision> GetSubdivisionById(Guid id);

        /// <summary>
        /// Remove subdivision from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSubdivision(Guid id);

        /// <summary>
        /// Add subdivision to database or update existing
        /// </summary>
        /// <param name="modifiedSubdivision"></param>
        public void AddOrUpdateSubdivision(Subdivision modifiedSubdivision);

        /// <summary>
        /// Get subdivision Name by its Id
        /// </summary>
        /// <param name="subdivision"></param>
        /// <returns></returns>
        public Guid GetSubdivisionIdByName(string subdivision);
    }
}
