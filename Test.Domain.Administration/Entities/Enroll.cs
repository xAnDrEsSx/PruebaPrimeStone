using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Domain.Administration.Entities
{
    [Table("Enroll")]
    public class Enroll
    {
        [Key]
        public int Id { get; set; }
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }

        [Column("Registration_Date", TypeName = "datetime2(7)")]
        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

        #region FK
        [ForeignKey("IdCourse")]
        public virtual Course Course { get; set; }

        [ForeignKey("IdStudent")]
        public virtual Student Student { get; set; }
        #endregion
    }
}
