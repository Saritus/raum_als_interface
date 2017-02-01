
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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
			// Create your application here

			//Vollbild ##############################################################
			ImageView image = FindViewById<ImageView>(Resource.Id.imageView2);
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
				if (imageVollbild_on == true)//Öffnet Vollbildansicht
				{
					vollbildlayout.Visibility = ViewStates.Gone;
					imageVollbild_on = false;
				}
			};
			//Vollbild ENDE ##############################################################



			//Drop Infos anzeigen #############################################

			//Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs
			string text = Intent.GetStringExtra("MyData") ?? "Data not available";
			//Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs ENDE
			 

			TextView titel = FindViewById<TextView>(Resource.Id.textView22);
			TextView raum = FindViewById<TextView>(Resource.Id.textView3); 
			TextView beschreibung = FindViewById<TextView>(Resource.Id.textView1);
			TextView datum = FindViewById<TextView>(Resource.Id.textView239);
			ImageView bild = FindViewById<ImageView>(Resource.Id.imageView2); 


			//titel.Text = "Der Titel";
			titel.Text = text;
			raum.Text = "Raum...";
			beschreibung.Text = "Hier muss die Beschreibung beschrieben sein";
			//bild.SetImageURI(Android.Net.Uri.Parse("hier muss der Pfad des Bildes als String rein"));
			datum.Text = "Datum steht hier";


			//Drop Infos anzeigen ENDE #############################################

		}
	}
}
