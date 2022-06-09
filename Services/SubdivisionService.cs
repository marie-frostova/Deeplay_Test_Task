using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deeplay_EnterprisePersonnelAccounting.Services
{
    public class SubdivisionService : ISubdivisionService
    {
        private DBContext db;

        public SubdivisionService(DBContext db)
        {
            this.db = db;
        }

        public Task<List<Subdivision>> GetAllSubdivisions()
        {
            var res = db.Subdivisions.ToList();
            return Task.FromResult(res);
        }

        public Task<Subdivision> GetSubdivisionById(Guid id)
        {
            var res = db.Subdivisions.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(res);
        }

        public void DeleteSubdivision(Guid id)
        {
            db.Subdivisions.Remove(GetSubdivisionById(id).Result);
            db.SaveChanges();
        }

        public void AddOrUpdateSubdivision(Subdivision modifiedSubdivision)
        {
            var subdivision = db.Subdivisions.FirstOrDefault(s => modifiedSubdivision.Id == s.Id);
            if (subdivision == null)
                db.Subdivisions.Add(modifiedSubdivision);
            else
                subdivision.SubdivisionName = modifiedSubdivision.SubdivisionName;
            db.SaveChanges();
        }

        public Guid GetSubdivisionIdByName(string subdivision)
        {
            var res = db.Subdivisions.FirstOrDefault(s => s.SubdivisionName == subdivision);
            return res == null ? new Guid() : res.Id;
        }
    }
}
