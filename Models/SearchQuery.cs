using System;
using System.Collections.Generic;

namespace Deeplay_EnterprisePersonnelAccounting.Models
{
    public class SearchQuery
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string Position { get; set; }
        public Guid PositionId { get; set; }

        public string Subdivision { get; set; }
        public Guid SubdivisionId { get; set; }

        public int ResultsPerPage { get; set; }
        public int Page { get; set; }
        public int ResultCount  { get; set; }
        public List<Employee> Result { get; set; }

        public SearchQuery()
        {
            ResultsPerPage = 10;
        }
    }
}
