using Android.Graphics;
using System.Collections.Generic;

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

    }
}