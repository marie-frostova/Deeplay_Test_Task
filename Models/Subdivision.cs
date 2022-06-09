using System;
using System.ComponentModel.DataAnnotations;

namespace Deeplay_EnterprisePersonnelAccounting.Models
{
    public class Subdivision
    {
        [Key]
        public Guid Id { get; set; }

        public string SubdivisionName { get; set; }

        public Subdivision()
        {
            Id = Guid.NewGuid();
            SubdivisionName = "";
        }
    }
}
