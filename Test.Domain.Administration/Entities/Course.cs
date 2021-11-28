using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Domain.Administration.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }

        /// <summary>
        /// Fecha de inicio curso
        /// </summary>
        [Column("Start_Date", TypeName = "datetime2(7)")]
        public DateTime StartDate { get; set; }

        public bool Active { get; set; }
    }
}
