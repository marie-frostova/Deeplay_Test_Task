using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using Deeplay_EnterprisePersonnelAccounting.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deeplay_EnterprisePersonnelAccounting.Controllers
{
    public class SubdivisionController : Controller
    {
        public DBContext db { get; set; }
        public ISubdivisionService subdivisionService;

        public SubdivisionController(DBContext db)
        {
            this.db = db;
            subdivisionService = new SubdivisionService(db);
        }

        /// <summary>
        /// Show all subdivisions
        /// </summary>
        /// <returns></returns>
        public IActionResult ListSubdivisions()
        {
            var subdivisions = subdivisionService.GetAllSubdivisions().Result;
            return View(subdivisions);
        }

        /// <summary>
        /// Edit subdivision's Name
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public IActionResult EditSubdivision([FromQuery] string strId = "")
        {
            Subdivision subdivision;
            if (strId != "")
            {
                var Id = Guid.Parse(strId);
                subdivision = subdivisionService.GetSubdivisionById(Id).Result;
            }
            else
            {
                subdivision = new Subdivision();
            }
            return View(subdivision);
        }

        /// <summary>
        /// Remove subdivision
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public IActionResult DeleteSubdivision([FromQuery] string strId)
        {
            if (strId != null)
                subdivisionService.DeleteSubdivision(Guid.Parse(strId));
            return Redirect("/Subdivision/ListSubdivisions");
        }

        /// <summary>
        /// Add or update subdivision
        /// </summary>
        /// <param name="subdivision"></param>
        /// <returns></returns>
        public IActionResult AddOrUpdateSubdivision(Subdivision subdivision)
        {
            subdivisionService.AddOrUpdateSubdivision(subdivision);
            return Redirect("/Subdivision/ListSubdivisions");
        }
    }
}
