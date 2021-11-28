namespace Common.ApplicationModel.Response
{
    public class ResponseModel
    {

        /// <summary>
        /// Código del retorno del servicio
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Mensaje por defecto
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Objeto de respuesta
        /// </summary>
        public object Response { get; set; }
    }
}
