using System.Threading.Tasks;
using Flurl.Http;
using fandom.Model;
using Flurl;

namespace fandom.WindowsForms
{
    class APIService
    {
        private readonly string _route = null;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search = null)
        {
            var url = $"{Properties.Settings.Default.API}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.GetJsonAsync<T>();
        }


        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.API}/{_route}";

            return await url.PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(object id)
        {
            var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
            return await url.DeleteAsync().ReceiveJson<T>();
        }
    }
}
