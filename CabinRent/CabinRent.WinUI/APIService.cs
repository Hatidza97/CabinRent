using Flurl.Http;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CabinRent.Model;
namespace CabinRent.WinUI
{
    public class APIService
    {
        private string _resource = null;
        //public string _endpoint = Properties.Settings.Default.APIUrl;
        public string _endpoint = "https://localhost:7012/api";
        public static string Username = null;
        public static string Password = null;

        public APIService(string resource)
        {
            _resource = resource;
        }

       public async Task<T> Get<T>(object search = null)
        {
            try
            {
                var query = "";
                if (search != null)
                {
                    query = await search?.ToQueryString();
                }
                //  get all ako je null
                var list = await $"{_endpoint}/{_resource}?{query}"
                  .WithBasicAuth(Username, Password)
                  .GetJsonAsync<T>();
                return list;
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }

        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}/{_resource}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }
        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{_endpoint}/{_resource}";

                return await url
                    .WithBasicAuth(Username, Password)
                    .PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }
        }

        public async Task<T> Post<T>(object request)
        {
            try
            {
                var result = await $"{_endpoint}/{_resource}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{_endpoint}/{_resource}/{id}";

                return await url
                    .WithBasicAuth(Username, Password)
                    .PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }

        }
        public async Task<T> Put<T>(object id, object request)
        {
            var result = await $"{_endpoint}/{_resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
        private async Task<T> HandleException<T>(FlurlHttpException ex)
        {
            if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Niste autentifikovani.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                MessageBox.Show("Nemate pravo pristupa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return default;
        }
    }
}
