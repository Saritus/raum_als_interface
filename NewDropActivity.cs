
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace TouchWalkthrough
{
    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }

    [Activity(Label = "NewDropActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class NewDropActivity : Activity
    {
        private ImageView imageViewPicture;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume to much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageViewPicture.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            if (App.bitmap != null)
            {
                imageViewPicture.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Plus_Menue);
            // Create your application here

            //File-Picker ###############################################################
            /*Button filepicker_button = FindViewById<Button>(Resource.Id.imageButton1);
			filepicker_button.Click += (object sender, EventArgs e) =>
			{

			};*/
            //File-Picker ENDE ###########################################################


            //Take Picture ###############################################################
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                ImageView imageViewPicture = FindViewById<ImageView>(Resource.Id.imageView1);
                ImageButton take_picture_button = FindViewById<ImageButton>(Resource.Id.imageButton2);
                take_picture_button.Click += TakeAPicture;
            }
            //Take Picture ENDE ###########################################################
        }




        //Take Picture ###############################################################
        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
            StartActivityForResult(intent, 0);
        }
        //Take Picture ENDE ###########################################################

    }
}
