using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Answers_APP_Examen_KeirynS.Models
{
    public class User
    {
        [JsonIgnore]
        public RestRequest? Request { get; set; }
        public int UsuarioID { get; set; }

        public string? Correo { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? Contrasennia { get; set; }

        public int RolID { get; set; }

        public string? RolDescripcion { get; set; }
        public async Task<bool> AddUserAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("Users/AddUserFromApp");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de seguridad API Key 
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //cuando enviamos objetos hacia el API dedbemos seriaolizarlos antes

                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel);

                //Ahora se ejecuta la llamada 
                RestResponse response = await client.ExecuteAsync(Request);

                //Validamos el resultado del llamado al API
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }
    }

}

