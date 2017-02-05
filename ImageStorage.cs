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
    }
}