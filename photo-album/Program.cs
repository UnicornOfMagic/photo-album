using System;

namespace photo_album
{
    public class Program
    {
        static void Main(string[] args)
        {
            var photoService = new JSonPlaceHolderPhotoService();
            var photoRetriever = new PhotoRetriever(photoService);

            if (!int.TryParse(args[0], out var value)) return;

            var photos = photoRetriever.GetPhotosByAlbumId(value).GetAwaiter().GetResult();
            
            foreach (var photo in photos)
            {
                Console.WriteLine(photo);
            }
        }
    }
}
