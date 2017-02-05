using Android.Content;
using Android.Graphics;
using Android.Provider;
using System.Collections.Generic;
using System.Net;

namespace TouchWalkthrough
{
    public class ImageStorage
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

        private static Dictionary<string, Bitmap> images;

        public Bitmap getBitmap(string path)
        {
            Bitmap bitmap;
            images.TryGetValue(path, out bitmap);
            return bitmap;
        }

        public void addBitmap(string path, Bitmap bitmap)
        {
            images.Add(path, bitmap);
        }

        public void addURL(string path)
        {
            if (!images.ContainsKey(path))
            {
                Bitmap bitmap = GetImageBitmapFromUrl(path);
                addBitmap(path, bitmap);
            }
        }

        private Bitmap GetImageBitmapFromUrl(string url)
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

        public void addURI(string path, Android.Net.Uri uri, ContentResolver cr)
        {
            Bitmap bitmap = MediaStore.Images.Media.GetBitmap(cr, uri);
            addBitmap(path, bitmap);
        }

        public void saveImages(string filename)
        {
            XML.Save(images, filename);
        }

        public void loadImages(string filename)
        {
            images = XML.Load<Dictionary<string, Bitmap>>(filename);
        }
    }
}