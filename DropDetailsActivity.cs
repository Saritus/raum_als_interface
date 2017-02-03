
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Net;
using Uri = Android.Net.Uri;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Environment = Android.OS.Environment;


namespace TouchWalkthrough
{
    [Activity(Label = "DropDetailsActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class DropDetailsActivity : Activity
    {
        DropManager dropmanager = DropManager.Instance;
        bool imageVollbild_on = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DropDetails);

            //Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs
            int id = Intent.GetIntExtra("ID", -1);
            //Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs ENDE

            // Create your application here

            //Vollbild ##############################################################
            ImageView image = FindViewById<ImageView>(Resource.Id.imageView2);//nicht Vollbild
			ImageView imageVollbild = FindViewById<ImageView>(Resource.Id.imageView3);//Vollbild
            RelativeLayout vollbildlayout = FindViewById<RelativeLayout>(Resource.Id.Vollbildlayout);
            vollbildlayout.Visibility = ViewStates.Gone;

            image.Click += (object sender, EventArgs e) =>
            {
                if (imageVollbild_on == false)//Öffnet Vollbildansicht
                {
                    vollbildlayout.Visibility = ViewStates.Visible;
                    imageVollbild_on = true;
                }
            };

            vollbildlayout.Click += (object sender, EventArgs e) =>
            {
                if (imageVollbild_on == true)//Schließt Vollbildansicht
                {
                    vollbildlayout.Visibility = ViewStates.Gone;
                    imageVollbild_on = false;
                }
            };
            //Vollbild ENDE ##############################################################



            //Drop Infos anzeigen #############################################

            Drop drop = dropmanager.drops[id];

            TextView titel = FindViewById<TextView>(Resource.Id.textView22);
            TextView raum = FindViewById<TextView>(Resource.Id.textView3);
            TextView beschreibung = FindViewById<TextView>(Resource.Id.textView1);
            TextView datum = FindViewById<TextView>(Resource.Id.textView239);

            
            titel.Text = drop.name;
            raum.Text = drop.location.name;
            beschreibung.Text = drop.description;

			//File file = new File(drop.picturePath);
			//Uri contentUri = Uri.FromFile(file);
			//image.SetImageURI(contentUri);
			//imageVollbild.SetImageURI(contentUri);

            datum.Text = drop.startTime.ToString("dd.MM.yyyy");
            //Drop Infos anzeigen ENDE #############################################

        }
    }
}
