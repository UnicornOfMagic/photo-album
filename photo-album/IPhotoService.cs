using System.Collections.Generic;
using System.Threading.Tasks;

namespace photo_album
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotosByAlbumId(int id);
    }
}