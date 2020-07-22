using System;

namespace photo_album
{
    public class Program
    {
        static void Main(string[] args)
        {
            var photoService = new JSonPlaceHolderPhotoService();
            var photoRetriever = new PhotoRetriever(photoService);

            if (args.Length == 0)
            {
                Console.WriteLine(
                    "Missing Parameter. Valid usage is a single integer between 1-100 selecting an album.");
                return;
            }
            if(!int.TryParse(args[0], out var value )|| value > 100 || value < 1)
            {
                Console.WriteLine(
                    "Invalid Parameter. Valid usage is a single integer between 1-100 selecting an album.");
                return;
            }

            var photos = photoRetriever.GetPhotosByAlbumId(value).GetAwaiter().GetResult();
            
            foreach (var photo in photos)
            {
                Console.WriteLine(photo);
            }
        }
    }
}
