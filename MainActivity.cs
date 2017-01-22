namespace TouchWalkthrough
{
	using System;
	using Android.App;
	using Android.OS;
	using Android.Views;
	using Android.Widget;
	using System.Collections.Generic; //For ListView

	//
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/logo", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		bool filter_button_on = false;
		bool hap1_button_on = false;
		bool hap2_button_on = false;
		bool hap3_button_on = false;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			//OPEN-HISTORY##############################################################
			ImageButton history_button = FindViewById<ImageButton>(Resource.Id.imageButton6);
			history_button.Click += (object sender, EventArgs e) =>
			{
				StartActivity(typeof(HistoryActivity));
			};
			//OPEN-HISTORY ENDE ##############################################################


			//For Filter-Button open menue##############################################################
			ImageButton filter_button = FindViewById<ImageButton>(Resource.Id.imageButton2);
			RelativeLayout showFilterLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayoutFilter);

			filter_button.Click += (object sender, EventArgs e) =>
			{
				if (filter_button_on == false)//Öffnet Untermenü
				{
					showFilterLayout.Visibility = ViewStates.Visible;
					filter_button_on = true;
				}
				else
				{//Schließt Untermenü
					showFilterLayout.Visibility = ViewStates.Gone;
					filter_button_on = false;
				}
			};
			//For Filter-Button open menue ENDE ##############################################################

			//For Filter-Button ON/OFF FILTER ###########################################################
			ImageButton hap1_button = FindViewById<ImageButton>(Resource.Id.imageButton99);
			hap1_button.Click += (object sender, EventArgs e) =>
			{
				if (hap1_button_on == false)
				{
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1_off);
					hap1_button_on = true;
				}
				else {
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1);
					hap1_button_on = false;
				}
			};
			//############ 
			ImageButton hap2_button = FindViewById<ImageButton>(Resource.Id.imageButton98);
			hap2_button.Click += (object sender, EventArgs e) =>
			{
				if (hap2_button_on == false)
				{
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2_off);
					hap2_button_on = true;
				}
				else {
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2);
					hap2_button_on = false;
				}
			};
			//############
			ImageButton hap3_button = FindViewById<ImageButton>(Resource.Id.imageButton97);
			hap3_button.Click += (object sender, EventArgs e) =>
			{
				if (hap3_button_on == false)
				{
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3_off);
					hap3_button_on = true;
				}
				else {
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3);
					hap3_button_on = false;
				}
			};
			//For Filter-Button ON/OFF FILTER ###########################################################

			//OPEN CREAT NEW DROP (Plus-Button) ##########################################################
			ImageButton plus_button = FindViewById<ImageButton>(Resource.Id.imageButton1);
			plus_button.Click += (object sender, EventArgs e) =>
			{
				StartActivity(typeof(NewDropActivity));
			};
			//OPEN CREAT NEW DROP (Plus-Button) ENDE ##########################################################

			//For arrow_left Button ##############################################################
			ImageView karte = FindViewById<ImageView>(Resource.Id.imageViewKarte);
			ImageButton arrow_left_button = FindViewById<ImageButton>(Resource.Id.imageButton3);
			arrow_left_button.Click += (object sender, EventArgs e) =>
			{
				karte.SetImageResource(Resource.Drawable.test_platzhalter_andere_karte);
			};
			//For arrow_left Button ENDE ##############################################################

		}

		//Use Hardware-Back-Button ##############################################################
		public override void OnBackPressed()
		{
			var alert = new AlertDialog.Builder(this);
			alert.SetTitle("Verlassen");
			alert.SetMessage("Möchtest du die Anwendung beenden?");
			alert.SetPositiveButton("Ja", (senderAlert, args) =>
			{
				base.OnBackPressed();
			});

			alert.SetNegativeButton("Nein", (senderAlert, args) =>
			{
				//do nothing
			});

			Dialog dialog = alert.Create();
			dialog.Show();
		} 
		//Use Hardware-Back-Button ENDE ##############################################################
    }
}


