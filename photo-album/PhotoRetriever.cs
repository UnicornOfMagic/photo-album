using System.Collections.Generic;
using System.Threading.Tasks;

namespace photo_album
{
    public class PhotoRetriever
    {
        private IPhotoService _photoService;

        public PhotoRetriever(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IEnumerable<Photo>> GetPhotosByAlbumId(int id)
        {
            return await _photoService.GetPhotosByAlbumId(id);
        }

        public async Task<IEnumerable<Photo>> GetAllPhotos()
        {
            return await _photoService.GetAllPhotos();
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            return await _photoService.GetPhotoById(id);
        }
    }
}