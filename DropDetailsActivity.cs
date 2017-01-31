
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			}
	}
}
