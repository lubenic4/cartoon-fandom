using System.Threading.Tasks;
using Flurl.Http;
using fandom.Model;

namespace fandom.WindowsForms
{
    class APIService
    {
        private readonly string _route = null;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.API}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.GetJsonAsync<T>();
        }

        public async Task<T> GetAll<T>()
        {
            var url = $"{Properties.Settings.Default.API}/{_route}";

            return await url.GetJsonAsync<T>();
        }

    }
}
