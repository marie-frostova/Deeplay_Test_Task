using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deeplay_EnterprisePersonnelAccounting.Models
{
    public enum Sex { Male, Female };
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }

        public Guid PositionId { get; set; }

        [NotMapped]
        public Position Position { get; set; }

        public Guid SubdivisionId { get; set; }

        [NotMapped]
        public Subdivision Subdivision { get; set; }

        [NotMapped]
        public List<Employee> Subordinates { get; set; }

        public Guid LineManagerId { get; set; }

        [NotMapped]
        public Employee LineManager { get; set; }

        public Employee()
        {
            Id = Guid.NewGuid();
            Name = "";
            Surname = "";
            Patronymic = "";
        }
    }
}
