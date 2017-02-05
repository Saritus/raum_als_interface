using Android.Graphics;
using System.Collections.Generic;
using System.Net;

namespace TouchWalkthrough
{
    class ImageStorage
    {
        // Singelton-part

        private static ImageStorage instance;

        private ImageStorage()
        {
            images = new Dictionary<string, Bitmap>();
        }

        public static ImageStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageStorage();
                }
                return instance;
            }
        }

        // Storage-part

        static Dictionary<string, Bitmap> images;

        public static Bitmap getBitmap(string path)
        {
            Bitmap bitmap;
            images.TryGetValue(path, out bitmap);
            return bitmap;
        }

        public static void addBitmap(string path, Bitmap bitmap)
        {
            images.Add(path, bitmap);
        }

        public static void addURL(string path)
        {
            Bitmap bitmap = GetImageBitmapFromUrl(path);
            addBitmap(path, bitmap);
        }

        private static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}