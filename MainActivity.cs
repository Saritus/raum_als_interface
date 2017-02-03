namespace TouchWalkthrough
{

	using System;
	using Android.App;
	using Android.OS;
	using Android.Views;
	using Android.Widget;
	using Android.Content;
	using Android.Content.PM;
	using Android.Graphics;
	using Android.Provider;
	using Java.IO;
	using Environment = Android.OS.Environment;
	using Uri = Android.Net.Uri;
	using System.Collections.Generic; //For ListView

	//
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/logo", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		bool filter_button_on = false;
		bool hap1_button_on = false;
		bool hap2_button_on = true;
		bool hap3_button_on = true;
		DropManager dropmanager = DropManager.Instance;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
 			SetContentView(Resource.Layout.Main);

            DropManager.Instance.updateDrops();//bringt an der stelle nur 1x und zwar beim start der app was

			//Drops auf Karte darstellen ###########################################################
			ImageButton aktualisieren = FindViewById<ImageButton>(Resource.Id.imageButton104);
			aktualisieren.Click += (object sender, EventArgs e) =>
			{
				List<Drop> mapDrops = dropmanager.drops;
				RelativeLayout maplayout = FindViewById<RelativeLayout>(Resource.Id.RelativeLayoutMap);
				for (int i = 0; i < mapDrops.Count; i++)
				{
					ImageButton testbutton = new ImageButton(this);
					switch (mapDrops[i].category)
					{
						case Category.EVENT:
							testbutton.SetImageResource(Resource.Drawable.icon_hap1);
							break;
						case Category.WARNING:
							testbutton.SetImageResource(Resource.Drawable.icon_hap2);
							break;
						case Category.VOTE:
							testbutton.SetImageResource(Resource.Drawable.icon_hap3);
							break;
					}
					testbutton.SetBackgroundColor(Color.Transparent);
					maplayout.AddView(testbutton);
					testbutton.SetX(50 + 5 * i);
					testbutton.SetY(50 + 50 * i);

					//testbutton.SetX(mapDrops[i].location.position.X);
					//testbutton.SetY(mapDrops[i].location.position.Y);
				}
			};
			//Drops auf Karte darstellen ###########################################################




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
			TextView text1 = FindViewById<TextView>(Resource.Id.textView21);
			ImageButton hap1_button = FindViewById<ImageButton>(Resource.Id.imageButton99);
			hap1_button.Click += (object sender, EventArgs e) =>
			{
				if (hap1_button_on == false)
				{
					text1.SetTextColor(Color.Rgb(189, 189, 189));
					text1.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1_off);
					hap1_button_on = true;
				}
				else {
					text1.SetTextColor(Color.Rgb(97, 97, 97));
					text1.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1);
					hap1_button_on = false;
				}
			};
			//############ 
			TextView text2 = FindViewById<TextView>(Resource.Id.textView3);
			ImageButton hap2_button = FindViewById<ImageButton>(Resource.Id.imageButton98);
			hap2_button.Click += (object sender, EventArgs e) =>
			{
				if (hap2_button_on == false)
				{
					text2.SetTextColor(Color.Rgb(189, 189, 189));
					text2.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2_off);
					hap2_button_on = true;
				}
				else {
					text2.SetTextColor(Color.Rgb(97, 97, 97));
					text2.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2);
					hap2_button_on = false;
				}
			};
			//############
			TextView text3 = FindViewById<TextView>(Resource.Id.textView2);
			ImageButton hap3_button = FindViewById<ImageButton>(Resource.Id.imageButton97);
			hap3_button.Click += (object sender, EventArgs e) =>
			{
				if (hap3_button_on == false)
				{
					text3.SetTextColor(Color.Rgb(189, 189, 189));
					text3.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3_off);
					hap3_button_on = true;
				}
				else {
					text3.SetTextColor(Color.Rgb(97, 97, 97));
					text3.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3);
					hap3_button_on = false;
				}
			};
			//For Filter-Button ON/OFF FILTER ENDE###########################################################

			//OPEN CREAT NEW DROP (Plus-Button) ##########################################################
			ImageButton plus_button = FindViewById<ImageButton>(Resource.Id.imageButton1);
			plus_button.Click += (object sender, EventArgs e) =>
			{
				StartActivity(typeof(NewDropActivity));
			};
			//OPEN CREAT NEW DROP (Plus-Button) ENDE ##########################################################

			//For arrow_left Button ##############################################################
			//ImageView karte = FindViewById<ImageView>(Resource.Id.imageViewKarte);
			ImageButton arrow_left_button = FindViewById<ImageButton>(Resource.Id.imageButton3);
			arrow_left_button.Click += (object sender, EventArgs e) =>
			{
				//karte.SetImageResource(Resource.Drawable.test_platzhalter_andere_karte);
			};
			//For arrow_left Button ENDE ##############################################################

		}

		//Use Hardware-Back-Button ##############################################################
		public override void OnBackPressed()
		{
			ContextThemeWrapper ctw = new ContextThemeWrapper(this, Resource.Style.MyAppTheme);
			var alert = new AlertDialog.Builder(ctw);//Resource.Style.MyAppTheme
			alert.SetTitle("Verlassen");
			alert.SetMessage("Möchtest du die Anwendung beenden?");
			alert.SetPositiveButton("Ja", (senderAlert, args) =>
			{
				//base.OnBackPressed();
				base.Finish();
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