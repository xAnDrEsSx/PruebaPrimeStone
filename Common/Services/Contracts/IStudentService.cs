using Common.ApplicationModel;
using System;
using System.Collections.Generic;
using Test.Domain.Administration.Entities;

namespace Common.Services.Contracts
{
    public interface IStudentService
    {
        /// <summary>
        /// Obtener toda la lista de Estudiantes
        /// </summary>
        /// <returns></returns>
        public List<StudentAM> GetAll();

        /// <summary>
        /// Obtener Estudiante
        /// </summary>
        /// <returns></returns>
        public StudentAM GetStudentById(int Id);

        /// <summary>
        /// Obtener Estudiante por # doc
        /// </summary>
        /// <returns></returns>
        public StudentAM GetStudentByDocumentNumber(int documentNumber);

        /// <summary>
        /// Crear un Estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, Student> AddStudent(StudentAM student);

        /// <summary>
        /// Actualizar un Estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, Student> UpdateStudent(StudentAM student);

        /// <summary>
        /// Borrar estudiante
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int Id);

        /// <summary>
        /// Valida si Existe estudiante
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ExistStudent(int Id);


        /// <summary>
        /// Valida si Existe ya un estudiante con ese numero de documento
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ExistDocument(int documentNumber);


    }
}
