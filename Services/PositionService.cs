using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Services
{
    public class PositionService : IPositionService
    {
        private DBContext db;

        public PositionService(DBContext db)
        {
            this.db = db;
        }

        public Task<List<Position>> GetAllPositions()
        {
            var res = db.Positions.ToList();
            return Task.FromResult(res);
        }

        public Task<Position> GetPositionById(Guid id)
        {
            var res = db.Positions.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(res);
        }

        public void DeletePosition(Guid id)
        {
            db.Positions.Remove(GetPositionById(id).Result);
            db.SaveChanges();
        }

        public void AddOrUpdatePosition(Position modifiedPosition)
        {
            var position = db.Positions.FirstOrDefault(p => modifiedPosition.Id == p.Id);
            if (position == null)
                db.Positions.Add(modifiedPosition);
            else
                position.PositionName = modifiedPosition.PositionName;
            db.SaveChanges();
        }

        public Guid GetPositionIdByName(string position)
        {
            var res = db.Positions.FirstOrDefault(p => p.PositionName == position);
            return res == null ? new Guid() : res.Id;
        }
    }
}
