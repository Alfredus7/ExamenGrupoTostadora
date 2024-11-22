using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ExamenGrupoTostadora.WebApiClients
{
    /// <summary>
    /// The Corporate Api Client
    /// </summary>
    public sealed class WebApiClient : IDisposable
    {
        private bool disposed = false;
        private string ApiBaseAddress;
        private string _username;
        private readonly WebClient _client = new WebClient();
        private readonly string _apiCredenciales;

        /// <summary>
        /// The Corporate Api Client
        /// </summary>
        /// <param name="transmittionMedium">Type of medium you wish the api client to talk in (Default is JSON)</param>
        public WebApiClient(string username = "")
        {
            string value = string.Empty;
            ApiBaseAddress = "https://localhost:7244";
            _apiCredenciales = "admin@email.com:As12345!";

            _username = username;
            ResetWebClient();
        }

        private void ResetWebClient()
        {
            _client.Headers.Clear();
            _client.Headers[HttpRequestHeader.ContentType] = "application/json";
        }

        #region Methods

        #region TiposDePlantas

        /// <summary>
        /// GetTipoPlantaCodes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public CoorporateApiResult<T> GetTiposDePlantas<T>()
        {
            string address = "api/TipoPlanta";

            return GetData<T>(address);
        }

        public CoorporateApiResult<T> GetTipoPlantaById<T>(int id)
        {
            string address = $"api/TipoPlanta/{id}";

            return GetData<T>(address);
        }

        public CoorporateApiResult<bool> DeleteTipoPlantaById<T>(int id)
        {
            string recurso = $"api/TipoPlanta/{id}";

            string address = GenerateApiAddress(recurso);

            return DeleteEntity<bool>(address);
        }

        public CoorporateApiResult<TipoPlantaViewModel> PostTipoPlanta<TipoPlantaViewModel>(TipoPlantaViewModel modelTipoPlanta)
        {
            string recurso = $"api/TipoPlanta";
            string source = GenerateApiAddress(recurso);
            return PostData<TipoPlantaViewModel, TipoPlantaViewModel>(source, modelTipoPlanta);
        }

        public CoorporateApiResult<TU> PutTipoPlanta<T, TU>(int id, T model)
        {
            string recurso = $"api/TipoPlanta/{id}";
            string address = GenerateApiAddress(recurso);
            return PutData<T, TU>(model, address);
        }
        #endregion



        #region Plantas

        /// <summary>
        /// GetPlantaCodes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public CoorporateApiResult<T> GetPlantas<T>()
        {
            string address = "api/Planta";

            return GetData<T>(address);
        }

        public CoorporateApiResult<T> GetPlantaById<T>(int id)
        {
            string address = $"api/Planta/{id}";

            return GetData<T>(address);
        }

        public CoorporateApiResult<bool> DeletePlantaById<T>(int id)
        {
            string recurso = $"api/Planta/{id}";

            string address = GenerateApiAddress(recurso);

            return DeleteEntity<bool>(address);
        }

        public CoorporateApiResult<PlantaViewModel> PostPlanta<PlantaViewModel>(PlantaViewModel modelPlanta)
        {
            string recurso = $"api/Planta";
            string source = GenerateApiAddress(recurso);
            return PostData<PlantaViewModel, PlantaViewModel>(source, modelPlanta);
        }

        public CoorporateApiResult<TU> PutPlanta<T, TU>(int id, T model)
        {
            string recurso = $"api/Planta/{id}";
            string address = GenerateApiAddress(recurso);
            return PutData<T, TU>(model, address);
        }

        #endregion



        #endregion

        #region Private Methods

        private CoorporateApiResult<T> GetData<T>(string module)
        {
            string address = GenerateApiAddress(module);

            AddAuthenticationHeader();
            CoorporateApiResult<T> result = new CoorporateApiResult<T>();
            try
            {
                // Make the request
                var response = _client.DownloadString(address);
                result.Data = JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }

        private CoorporateApiResult<TU> PostData<T, TU>(T model, string module)
        {
            string address = GenerateApiAddress(module);

            // Deserialize the response into a GUID
            return PostData<T, TU>(address, model);
        }

        private CoorporateApiResult<TU> PutData<T, TU>(T model, string module)
        {
            string address = GenerateApiAddress(module);

            // Deserialize the response into a GUID
            return PutData<T, TU>(address, model);
        }

        private CoorporateApiResult<TU> PostData<T, TU>(string address, T model)
        {
            // Serialize the data we are sending in to JSON
            string serialisedData = JsonConvert.SerializeObject(model);

            AddAuthenticationHeader();

            CoorporateApiResult<TU> result = new CoorporateApiResult<TU>();
            try
            {
                // Make the request
                var response = _client.UploadString(address, serialisedData);
                result.Data = JsonConvert.DeserializeObject<TU>(response);
            }
            catch (Exception ex)
            {
                throw;
            }

            // Deserialize the response into a GUID
            return result;
        }

        private CoorporateApiResult<TU> PostToken<TU>(string address, string token)
        {
            // Serialize the data we are sending in to JSON
            //string serialisedData = JsonConvert.SerializeObject(model);

            AddAuthenticationHeader();

            CoorporateApiResult<TU> result = new CoorporateApiResult<TU>();
            try
            {
                // Make the request
                var response = _client.UploadString(address, token);
                result.Data = JsonConvert.DeserializeObject<TU>(response);
            }
            catch (Exception ex)
            {
                throw;
            }

            // Deserialize the response into a GUID
            return result;
        }

        private CoorporateApiResult<TU> PutData<T, TU>(string address, T model)
        {
            // Serialize the data we are sending in to JSON
            string serialisedData = JsonConvert.SerializeObject(model);

            AddAuthenticationHeader();


            CoorporateApiResult<TU> result = new CoorporateApiResult<TU>();
            try
            {
                // Make the request
                var response = _client.UploadString(address, "PUT", serialisedData);
                result.Data = JsonConvert.DeserializeObject<TU>(response);
            }
            catch (Exception ex)
            {
                throw;
            }

            // Deserialize the response into a GUID
            return result;
        }

        private CoorporateApiResult<bool> DeleteEntity<T>(string address)
        {
            AddAuthenticationHeader();
            CoorporateApiResult<bool> result = new CoorporateApiResult<bool>();
            try
            {
                // Make the request
                var response = _client.UploadString(address, "DELETE", string.Empty);
                result.Data = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        private string GenerateApiAddress(string controller)
        {
            return string.Format("{0}/{1}", ApiBaseAddress, controller);
        }


        private void AddAuthenticationHeader(WebRequest webRequest = null, System.Net.Http.HttpClient httpClient = null)
        {
            ResetWebClient();
            var byteArray = Encoding.ASCII.GetBytes(_apiCredenciales); // Encoding the username and password as ASCII.
            _client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(byteArray));

        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    _client.Dispose();
                }

                // Dispose unmanaged managed resources.

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}
