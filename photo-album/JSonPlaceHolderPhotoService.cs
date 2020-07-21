using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace photo_album
{
    public class JSonPlaceHolderPhotoService : IPhotoService
    {
        private const string JsonPlaceHolderPhotoUrl = "https://jsonplaceholder.typicode.com/photos";

        public async Task<IEnumerable<Photo>> GetPhotosByAlbumId(int id)
        {
            using var client = new HttpClient();
            
            var response = await client.GetAsync(JsonPlaceHolderPhotoUrl + $"?albumId={id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Photo>>(responseBody);
        }
    }
}