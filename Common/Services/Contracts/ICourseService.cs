using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Common.Services.Contracts
{
    public interface ICourseService
    {
        /// <summary>
        /// Obtener toda la lista de Cursos
        /// </summary>
        /// <returns></returns>
        public List<CourseAM> GetAll();

        /// <summary>
        /// Obtener Curso
        /// </summary>
        /// <returns></returns>
        public CourseAM GetCourseById(int Id);

        /// <summary>
        /// Crear un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, Course> AddCourse(CourseAM course);

        /// <summary>
        /// Actualizar un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, Course> UpdateCourse(CourseAM course);

        /// <summary>
        /// Borrar Curso
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteCourse(int Id);

        /// <summary>
        /// Valida si Existe Curso
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ExistCourse(int Id);
    }
}
