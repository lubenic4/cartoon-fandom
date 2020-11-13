using System.Threading.Tasks;
using Flurl.Http;
using fandom.Model;
using Flurl;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using fandom.Model.Requests;

namespace fandom.WindowsForms
{
  public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route = null;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search = null)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
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
                return default;
            }
        }


        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
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

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = "";
                if(request is EpisodeUpdateRequest)
                {
                    url = $"{Properties.Settings.Default.API}/{_route}/Update/{id}";
                }
                else
                {
                    url = $"{Properties.Settings.Default.API}/{_route}/{id}";
                }

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show("APIService - Update exception");
                return default(T);
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
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

        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }catch(FlurlHttpException ex)
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
    }
}
