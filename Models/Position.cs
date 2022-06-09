using System;
using System.ComponentModel.DataAnnotations;

namespace Deeplay_EnterprisePersonnelAccounting.Models
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; }

        public string PositionName { get; set; }

        public Position()
        {
            Id = Guid.NewGuid();
            PositionName = "";
        }
    }
}
