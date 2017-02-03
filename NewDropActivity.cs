using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Android.Views;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace TouchWalkthrough
{
	/*public static class App
	{
		public static File _file;
		public static File _dir;
		public static Bitmap bitmap;
	}*/

	[Activity(Label = "NewDropActivity", Theme = "@android:style/Theme.NoTitleBar")]
	public class NewDropActivity : Activity
	{
		bool hap1_button_on = false;
		bool hap2_button_on = true;
		bool hap3_button_on = true;
		bool start_date_is_open = false;
		bool end_date_is_open = false;
		bool time_switch_is_on = true;
		String imagepath = "";
		Category category = Category.EVENT;

		DropManager dropmanager = DropManager.Instance;

		//Take Picture################################
		//private ImageView imageViewPicture;
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			//Fuer FilePicker #############################
			if (requestCode == 1)
			{
				var imageView = FindViewById<ImageView>(Resource.Id.imageView1);
				imageView.SetImageURI(data.Data);
				imagepath = data.DataString;
			}
			//Fuer FilePicker ENDE #############################


			/*if (requestCode == 0)
			{
				// Make it available in the gallery
				Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
				Uri contentUri = Uri.FromFile(App._file);
				mediaScanIntent.SetData(contentUri);
				SendBroadcast(mediaScanIntent);

				// Display in ImageView. We will resize the bitmap to fit the display
				// Loading the full sized image will consume to much memory 
				// and cause the application to crash.

				int height = Resources.DisplayMetrics.HeightPixels;
				//int width = imageViewPicture.Height;
				int width = Resources.DisplayMetrics.WidthPixels;
				App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
				if (App.bitmap != null)
				{
					imageViewPicture.SetImageBitmap(App.bitmap);
					App.bitmap = null;
				}

				// Dispose of the Java side bitmap.
				GC.Collect();
			}*/
		}
		//Take Picture ENDE################################

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Plus_Menue);
			// Create your application here

			//#### Auf Karte platzieren #####
			LinearLayout textbutton = FindViewById<LinearLayout>(Resource.Id.RelLayoutdropplazieren);
			textbutton.Click += (object sender, EventArgs e) =>
			{
				StartActivity(typeof(MainActivity));
			};
			//#### Auf Karte platzieren ####ENDE

			//Date Picker##############################
			RelativeLayout datepickerlayout = FindViewById<RelativeLayout>(Resource.Id.datepickerlayout);
			DatePicker date_picker_startdate = FindViewById<DatePicker>(Resource.Id.datePicker3);
			DatePicker date_picker_enddate = FindViewById<DatePicker>(Resource.Id.datePicker4_enddate);
			TextView start_date = FindViewById<TextView>(Resource.Id.textView39);
			TextView end_date = FindViewById<TextView>(Resource.Id.textView29);
			Button beginn_Datum_button = FindViewById<Button>(Resource.Id.button6);
			Button ende_Datum_button = FindViewById<Button>(Resource.Id.button7);
			Button abbrechen_button = FindViewById<Button>(Resource.Id.button5);
			Button ok_button = FindViewById<Button>(Resource.Id.button4);

			datepickerlayout.Visibility = ViewStates.Gone;
			date_picker_startdate.Visibility = ViewStates.Gone;
			date_picker_enddate.Visibility = ViewStates.Gone;
			//öffne Datepicker
			start_date.Click += (object sender, EventArgs e) =>
			{
				date_picker_startdate.Visibility = ViewStates.Visible;
				date_picker_enddate.Visibility = ViewStates.Gone;
				datepickerlayout.Visibility = ViewStates.Visible;
				beginn_Datum_button.SetTextColor(Color.Rgb(69, 39, 160));
				beginn_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
				ende_Datum_button.SetTextColor(Color.Rgb(250, 250, 250));
				ende_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
			}; 
			 
			end_date.Click += (object sender, EventArgs e) =>
			{
				date_picker_startdate.Visibility = ViewStates.Gone;
				date_picker_enddate.Visibility = ViewStates.Visible;
				datepickerlayout.Visibility = ViewStates.Visible;
				ende_Datum_button.SetTextColor(Color.Rgb(69, 39, 160));
				ende_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
				beginn_Datum_button.SetTextColor(Color.Rgb(250, 250, 250));
				beginn_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
			};
			//öffne Datepicker ENDE

			//Wenn Datepicker geöffnet
			beginn_Datum_button.Click += (object sender, EventArgs e) =>
			{
				date_picker_startdate.Visibility = ViewStates.Visible;
				date_picker_enddate.Visibility = ViewStates.Gone;
				beginn_Datum_button.SetTextColor(Color.Rgb(69, 39, 160));
				beginn_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
				ende_Datum_button.SetTextColor(Color.Rgb(250, 250, 250));
				ende_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
			};

			ende_Datum_button.Click += (object sender, EventArgs e) =>
			{
				date_picker_startdate.Visibility = ViewStates.Gone;
				date_picker_enddate.Visibility = ViewStates.Visible;
				ende_Datum_button.SetTextColor(Color.Rgb(69, 39, 160));
				ende_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
				beginn_Datum_button.SetTextColor(Color.Rgb(250, 250, 250));
				beginn_Datum_button.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
			};

			abbrechen_button.Click += (object sender, EventArgs e) =>
			{
				datepickerlayout.Visibility = ViewStates.Gone;
			};

			ok_button.Click += (object sender, EventArgs e) =>
			{
				datepickerlayout.Visibility = ViewStates.Gone;
				start_date.Text = "" + date_picker_startdate.DayOfMonth + "." + (date_picker_startdate.Month + 1) + "." + date_picker_startdate.Year;
				end_date.Text = "" + date_picker_enddate.DayOfMonth + "." + (date_picker_enddate.Month + 1) + "." + date_picker_enddate.Year;
			
			};
			//Wenn Datepicker geöffnet ENDE

			//Date Picker ENDE##############################

			// Switch ganztägig ############################ 
			TextView start_time = FindViewById<TextView>(Resource.Id.textView33);
			TextView end_time = FindViewById<TextView>(Resource.Id.textView22);
			Switch switch_ganztaegig = FindViewById<Switch>(Resource.Id.switch_button);

			switch_ganztaegig.Click += (object sender, EventArgs e) =>
			{
				if (time_switch_is_on == false)
				{
					//start_time.Visibility = ViewStates.Visible;
					//end_time.Visibility = ViewStates.Visible;
					start_time.SetTextColor(Color.Rgb(128,124,123));
					end_time.SetTextColor(Color.Rgb(128, 124, 123));
					time_switch_is_on = true;
				}
				else {
					start_time.SetTextColor(Color.Transparent);
					end_time.SetTextColor(Color.Transparent);
					//start_time.Visibility = ViewStates.Gone;
					//end_time.Visibility = ViewStates.Gone;
					time_switch_is_on = false;
				}
			};
			//Switch ganztägig ENDE #####################



			//Time Picker ##############################

			//FEHLT NOCH :(	

			//Time Picker ENDE##############################




			//For Filter-Button ON/OFF FILTER ###########################################################
			ImageButton hap1_button = FindViewById<ImageButton>(Resource.Id.imageButton33);
			ImageButton hap2_button = FindViewById<ImageButton>(Resource.Id.imageButton44);
			ImageButton hap3_button = FindViewById<ImageButton>(Resource.Id.imageButton55);

			//Change Text
			TextView filter_name = FindViewById<TextView>(Resource.Id.textView1);

			hap1_button.Click += (object sender, EventArgs e) =>
			{
				if (hap1_button_on == false)
				{
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1_off);
					hap1_button_on = true;
				}
				else {
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2_off);
					hap2_button_on = true;
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3_off);
					hap3_button_on = true;

					hap1_button.SetImageResource(Resource.Drawable.icon_hap1);
					hap1_button_on = false;

					filter_name.Text = "EVENT";
                    category = Category.EVENT;
				}
			};
			//############ 

			hap2_button.Click += (object sender, EventArgs e) =>
			{
				if (hap2_button_on == false)
				{
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2_off);
					hap2_button_on = true;
				}
				else {
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1_off);
					hap1_button_on = true;
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3_off);
					hap3_button_on = true;


					hap2_button.SetImageResource(Resource.Drawable.icon_hap2);
					hap2_button_on = false;

					filter_name.Text = "WARNUNG";
                    category = Category.WARNING;
				}
			};
			//############
			hap3_button.Click += (object sender, EventArgs e) =>
			{
				if (hap3_button_on == false)
				{
					hap3_button.SetImageResource(Resource.Drawable.icon_hap3_off);
					hap3_button_on = true;
				}
				else {
					hap1_button.SetImageResource(Resource.Drawable.icon_hap1_off);
					hap1_button_on = true;
					hap2_button.SetImageResource(Resource.Drawable.icon_hap2_off);
					hap2_button_on = true;

					hap3_button.SetImageResource(Resource.Drawable.icon_hap3);
					hap3_button_on = false;

					filter_name.Text = "ABSTIMMUNG";
                    category = Category.VOTE;
				}
			};
			//For Filter-Button ON/OFF FILTER ENDE###########################################################

			//Kreuz+Haken Buttons ##################################################
			ImageButton kreuz_button = FindViewById<ImageButton>(Resource.Id.imageButton367);
			ImageButton haken_button = FindViewById<ImageButton>(Resource.Id.imageButton467);

			kreuz_button.Click += (object sender, EventArgs e) =>
			{
				ContextThemeWrapper ctw = new ContextThemeWrapper(this, Resource.Style.MyAppTheme);
				var alert = new AlertDialog.Builder(ctw);
				alert.SetTitle("Abbrechen?");
				alert.SetMessage("Alle Einstellungen gehen verloren.");
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
			};

			haken_button.Click += (object sender, EventArgs e) =>
			{
				//HTWLocation loctw = new HTWLocation("z902");
				//Drop newdrop = new Drop("test",Category.EVENT,"blabla",DateTime.Now,loctw);

				TextView titel = FindViewById<TextView>(Resource.Id.Text1);
				TextView beschreibung = FindViewById<TextView>(Resource.Id.Text2);
				//TextView kategorie = FindViewById<TextView>(Resource.Id.textView1);

				//Enum.Parse(typeof(Category),kategorie.Text);

				HTWLocation loctw = new HTWLocation("Z902");
				DateTime date = new DateTime(date_picker_startdate.Year, (date_picker_startdate.Month + 1), date_picker_startdate.DayOfMonth);
				Drop newdrop = new Drop(titel.Text, category, beschreibung.Text, date, loctw, imagepath);
				dropmanager.drops.Add(newdrop);


				base.OnBackPressed();
			};
			//Kreuz+Haken Buttons ENDE ##################################################



			//File-Picker ###############################################################
			//ImageButton filepicker_button = FindViewById<ImageButton>(Resource.Id.imageButton1);
			LinearLayout filepicker_button = FindViewById<LinearLayout>(Resource.Id.LinearFileFotoPick);
			filepicker_button.Click += delegate
			{
				var imageIntent = new Intent();
				imageIntent.SetType("image/*");
				imageIntent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 1);
			};
			//File-Picker ENDE ###########################################################


			//Take Picture ###############################################################
			/*if (IsThereAnAppToTakePictures())
			{
				CreateDirectoryForPictures();

				//ImageView imageViewPicture = FindViewById<ImageView>(Resource.Id.imageView1);
				ImageButton take_picture_button = FindViewById<ImageButton>(Resource.Id.imageButton2);
				take_picture_button.Click += TakeAPicture;
			}*/
			//Take Picture ENDE ###########################################################
		}




		//Take Picture ###############################################################
		/*private void CreateDirectoryForPictures()
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
		}*/ 
		//Take Picture ENDE ###########################################################

		//Use Hardware-Back-Button ##############################################################
		public override void OnBackPressed()
		{
			ContextThemeWrapper ctw = new ContextThemeWrapper(this, Resource.Style.MyAppTheme);
			var alert = new AlertDialog.Builder(ctw);
			alert.SetTitle("Abbrechen?");
			alert.SetMessage("Alle Einstellungen gehen verloren.");
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
