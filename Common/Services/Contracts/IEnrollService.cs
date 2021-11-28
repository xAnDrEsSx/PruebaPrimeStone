using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Common.Services.Contracts
{
    public interface IEnrollService
    {
        /// <summary>
        /// Registar Matricula
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, Enroll> AddEnroll(EnrollAM enrollAM);

        /// <summary>
        /// Cancelar/Borrar Matricular
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteEnroll(int Id);

        /// <summary>
        /// Valida si Existe la matricula
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ExistEnroll(int Id);

        /// <summary>
        /// Lista de cursos por Estudiante
        /// </summary>
        /// <param name="IdStudent"></param>
        /// <returns></returns>
        public ICollection<EnrollAM> GetAllEnrollsByStudent(int IdStudent);

        /// <summary>
        /// Obtener Matricula
        /// </summary>
        /// <param name="IdStudent"></param>
        /// <returns></returns>
        public EnrollAM GetEnroll(int IdStudent, int IdCourse);




    }
}
