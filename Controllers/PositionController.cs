using Deeplay_EnterprisePersonnelAccounting.Data;
using Deeplay_EnterprisePersonnelAccounting.Interfaces;
using Deeplay_EnterprisePersonnelAccounting.Models;
using Deeplay_EnterprisePersonnelAccounting.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Deeplay_EnterprisePersonnelAccounting.Controllers
{
    public class PositionController : Controller
    {
        public DBContext db { get; set; }
        public IPositionService positionService;

        public PositionController(DBContext db)
        {
            this.db = db;
            positionService = new PositionService(db);
        }

        /// <summary>
        /// Show all positions
        /// </summary>
        /// <returns></returns>
        public IActionResult ListPositions()
        {
            var positions = positionService.GetAllPositions().Result;
            return View(positions);
        }

        /// <summary>
        /// Edit position's name
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public IActionResult EditPosition([FromQuery] string strId = "")
        {
            Position position;
            if (strId != "")
            {
                var Id = Guid.Parse(strId);
                position = positionService.GetPositionById(Id).Result;
            }
            else
            {
                position = new Position();
            }
            return View(position);
        }

        /// <summary>
        /// Remove position
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public IActionResult DeletePosition([FromQuery] string strId)
        {
            if (strId != null)
                positionService.DeletePosition(Guid.Parse(strId));
            return Redirect("/Position/ListPositions");
        }

        /// <summary>
        /// Add or update position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IActionResult AddOrUpdatePosition(Position position)
        {
            positionService.AddOrUpdatePosition(position);
            return Redirect("/Position/ListPositions");
        }
    }
}
