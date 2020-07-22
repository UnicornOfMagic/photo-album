using System;

namespace photo_album
{
    public class Program
    {
        private static PhotoRetriever _photoRetriever;
        static void Main(string[] args)
        {
            var photoService = new JSonPlaceHolderPhotoService();
            _photoRetriever = new PhotoRetriever(photoService);
            var interactive = false;
            var help = false;

            foreach (var arg in args)
            {
                if (arg.Equals("--interactive") || arg.Equals("-i"))
                {
                    interactive = true;
                } else if (arg.Equals("--help") || arg.Equals("-h") || arg.Equals("-?"))
                {
                    help = true;
                }
            }

            if (interactive)
            {
                LaunchInteractiveMode();
                return;
            }

            if (help)
            {
                LaunchHelpMode();
                return;
            }

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

            GetPhotosByAlbumId(value);
        }

        private static void GetPhotosByAlbumId(int value)
        {
            var photos = _photoRetriever.GetPhotosByAlbumId(value).GetAwaiter().GetResult();

            foreach (var photo in photos)
            {
                Console.WriteLine(photo);
            }
        }

        private static void LaunchHelpMode()
        {
            Console.WriteLine("Valid usage parameters are as follows:");
            Console.WriteLine("-i or --interactive \t enables interactive mode");
            Console.WriteLine("-h or --help or -? \t opens this help menu");
        }

        private static void LaunchInteractiveMode()
        {
            var userQuit = false;
            Console.WriteLine("Welcome to the Photo Album interactive menu!");

            do
            {
                Console.WriteLine("\n**Main Menu**");
                Console.WriteLine("1) Get multiple photos by album id");
                Console.WriteLine("2) Get a single photo by photo id");
                Console.WriteLine("3) Get all photos (If you 👿 your console you'll ♥️  this️)");
                Console.WriteLine("4) Quit");
                Console.Write("\n\nPlease enter a menu selection: ");

                var userInput = Console.ReadKey();
                switch (userInput.KeyChar)
                {
                    case '1':
                        GetPhotoAlbumById();
                        break;
                    case '2':
                        GetSinglePhotoById();
                        break;
                    case '3':
                        GetAllPhotos();
                        break;
                    case '4':
                        userQuit = true;
                        break;
                    default:
                        Console.WriteLine("\nUnknown entry. Please try again.\n");
                        break;
                }
            } while (!userQuit);
            
            Console.WriteLine("\nThank you for using The Photo Album service");
            Console.WriteLine("Goodbye!");
        }

        private static void GetPhotoAlbumById()
        {
            var userQuit = false;
            do
            {
                Console.Write("\nPlease enter the ID of the album you wish to view (x to return to main menu): ");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var value))
                {
                    GetPhotosByAlbumId(value);
                }
                else if (userInput.Equals("x") || userInput.Equals("X"))
                {
                    userQuit = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid entry. Value must be a valid integer from 1-100.");
                }
            } while (!userQuit);
        }

        private static void GetSinglePhotoById()
        {
            var userQuit = false;
            do
            {
                Console.Write("\nPlease enter the ID of the photo you wish to view (x to return to main menu): ");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var value))
                {

                    var photo = _photoRetriever.GetPhotoById(value).GetAwaiter().GetResult();
                    Console.WriteLine("\nPhoto retrieved:");
                    Console.WriteLine(photo);
                }
                else if (userInput.Equals("x") || userInput.Equals("X"))
                {
                    userQuit = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid entry. Value must be a valid integer from 1-5000.");
                }
            } while (!userQuit);
        }

        private static void GetAllPhotos()
        {
            var allPhotos = _photoRetriever.GetAllPhotos().GetAwaiter().GetResult();
            foreach (var photo in allPhotos)
            {
                Console.WriteLine(photo);
            }
        }
    }
}
