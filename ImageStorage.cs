using Android.Content;
using Android.Graphics;
using Android.Provider;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TouchWalkthrough
{
    public class ImageStorage
    {
        // Singelton-part

        private static ImageStorage instance;

        private ImageStorage()
        {
            images = new Dictionary<string, Android.Net.Uri>();
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

        private static Dictionary<string, Android.Net.Uri> images;

        public Android.Net.Uri getURI(string path)
        {
            Android.Net.Uri uri;
            images.TryGetValue(path, out uri);
            return uri;
        }

        public void addURL(string path)
        {
            if (path != null && !images.ContainsKey(path))
            {
                try
                {
                    Bitmap bitmap = GetImageBitmapFromUrl(path);
                    Android.Net.Uri uri = SaveBitmap(bitmap, path);
                    images.Add(path, uri);
                }
                catch (System.Net.WebException) { }
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

        public void addURI(string path, Android.Net.Uri uri)
        {
            images.Add(path, uri);
        }

        Android.Net.Uri SaveBitmap(Bitmap bitmap, string filename)
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(sdCardPath, filename.GetHashCode().ToString());
            var stream = new FileStream(filePath, FileMode.Create);
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
            return Android.Net.Uri.Parse(filePath);
        }
    }
}