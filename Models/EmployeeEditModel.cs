using System.Collections.Generic;

namespace Deeplay_EnterprisePersonnelAccounting.Models
{
    public class EmployeeEditModel
    {
        public Employee Employee { get; set; }

        public List<Position> Positions { get; set; }

        public List<Subdivision> Subdivisions { get; set; }
    }
}
