using ApiConsumer.Models;
using ApiConsumer.Models.Listado;
using ApiConsumer.Models.login;
using ApiConsumer.Models.Psr;
using ApiConsumer.Services.ApiConsumer.Services.Recarags.Request;
using ApiConsumer.Services.ApiConsumer.Services.RecaragsListados.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiConsumer.Services
{
    public class ClaroNetService : BaseService
    {
        #region Usuarios
        public GenericResponse<UsuarioResponse> CrearUsuario(UsuarioRequest usuario, string token)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = "user/add";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Post<UsuarioResponse>(url, controller, usuario, headers);
        }
        public GenericResponse<LoginResponse> Log(LoginRequest login)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = "pcr/login";

            return Post<LoginResponse>(url, controller, login, null, "application/x-www-form-urlenconded");
        }
    
        public GenericResponse<ListadoUsuariosResponse> ListarUsuarios(int? desde, int? hasta, string token)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = $"user/list?desde={desde}&limite={hasta}";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Get<ListadoUsuariosResponse>(url, controller, null, headers);
        }
        public GenericResponse<UsuarioResponse> EditarUsuario(UsuarioRequest usuario, string token, string id)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = $"user/edit/{id} ";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Post<UsuarioResponse>(url, controller, usuario, headers);
        }
        public GenericResponse<UsuarioResponse> Inhabilitarusuario(UsuarioRequest usuario, string token, string id)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = $"user/enable/{id} ";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Post<UsuarioResponse>(url, controller, usuario, headers);
        }

        #endregion

        #region Psr
        public GenericResponse<UsuarioResponse> CrearPsr(PsrRequest usuario, string token)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = "pcr/add";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Post<UsuarioResponse>(url, controller, usuario, headers);
        }


        public GenericResponse<ListadoPsrResponse> ListarPsr(int? desde, int? hasta, string token)
        {
            string url = "https://backendclarov2.herokuapp.com";
            string controller = $"pcr/list?desde={desde}&limite={hasta}";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            return Get<ListadoPsrResponse>(url, controller, null, headers);
        }
        #endregion


        #region Recargas
        public GenericResponse<GetListadoResponse> ObtenerRecargasRecientes( string token)
        {
            string uri = "https://backendclarov2.herokuapp.com";
            string controller = "recarga/list";
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("token", $"{token}");
            IDictionary<string, List<string>> query = new Dictionary<string, List<string>>();
        
            query.Add("limite", new List<string> { "50" });
            return base.Get<GetListadoResponse>(uri, controller, query, headers);
        }
        #endregion

    }


    namespace ApiConsumer.Services.Recarags.Request
    {
        public class GetRecargasRequest
        {
            public string email { get; set; }
        }

        public class GetRecargasRequestRecientes
        {
            public string email { get; set; }
            public string fechaRecargaString { get; set; }
        }

        public class InsertRecargasRequest
        {

            [JsonProperty("pcr")]
            public string pcr { get; set; }
            [JsonProperty("mensaje")]
            public string mensaje { get; set; }
            [JsonProperty("email")]
            public string email { get; set; }

        }
    }
    namespace ApiConsumer.Services.RecaragsListados.Response
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class GetRecarga
        {

            [JsonProperty("fechaRecarga")]
            public DateTime fechaRecarga { get; set; }

            [JsonProperty("mensaje")]
            public string mensaje { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

        }

        public class GetListadoResponse
        {
            [JsonProperty("conteo")]
            public int conteo { get; set; }
            [JsonProperty("ok")]
            public bool ok { get; set; }
            [JsonProperty("recarga")]
            public List<GetRecarga> recarga { get; set; }

        }
    }
}
