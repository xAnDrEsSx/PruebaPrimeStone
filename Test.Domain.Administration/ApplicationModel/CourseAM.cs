using System;

namespace Test.Domain.Administration.ApplicationModel
{
    public class CourseAM
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int Hours { get; set; }
        public DateTime StartDate { get;set;}

        /// <summary>
        /// Valida si esta matriculado S/N
        /// </summary>
        public string Enrolled { get; set; } = "N";

        public bool Active { get; set; } = true;
    }
}
