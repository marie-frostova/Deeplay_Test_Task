using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Interfaces
{
    public interface IPositionService
    {
        /// <summary>
        /// Gets all positions from database
        /// </summary>
        /// <returns></returns>
        public Task<List<Position>> GetAllPositions();

        /// <summary>
        /// Gets position from database by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Position> GetPositionById(Guid id);

        /// <summary>
        /// Remove position from database
        /// </summary>
        /// <param name="id"></param>
        public void DeletePosition(Guid id);

        /// <summary>
        /// Add position to database or update existing
        /// </summary>
        /// <param name="modifiedPosition"></param>
        public void AddOrUpdatePosition(Position modifiedPosition);

        /// <summary>
        /// Get position Name by its Id
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Guid GetPositionIdByName(string position);
    }
}
