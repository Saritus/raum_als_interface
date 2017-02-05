
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;


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
            string id = Intent.GetStringExtra("ID");
            Drop drop = dropmanager.getDrop(id);
            //Emfpange Daten des angelickten drops von der Activity HistoryActivity.cs ENDE

            // Create your application here

            // Kategorie
            ImageView category = FindViewById<ImageView>(Resource.Id.imageView1);
            category.SetImageResource(drop.GetIconId("art"));
            // Kategorie Ende

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

            TextView titel = FindViewById<TextView>(Resource.Id.textView22);
            TextView raum = FindViewById<TextView>(Resource.Id.textView3);
            TextView beschreibung = FindViewById<TextView>(Resource.Id.textView1);
            TextView startdatum = FindViewById<TextView>(Resource.Id.textView39);
            TextView enddatum = FindViewById<TextView>(Resource.Id.textView29);

            titel.Text = drop.name;
            raum.Text = drop.location.name;
            beschreibung.Text = drop.description;

            //File file = new File(drop.picturePath);
            //Uri contentUri = Uri.FromFile(file);
            //image.SetImageURI(contentUri);
            //imageVollbild.SetImageURI(contentUri);

            startdatum.Text = drop.startTime.ToString("dd.MM.yyyy");
            enddatum.Text = drop.endTime.ToString("dd.MM.yyyy");
            //Drop Infos anzeigen ENDE #############################################

            // Switch
            Switch ignore_switch = FindViewById<Switch>(Resource.Id.switch_button);

            ignore_switch.Checked = drop.ignored;

            ignore_switch.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                drop.ignored = ignore_switch.Checked;
            };
			// Switch ENDE

			//Auf Karte anzeigen
			LinearLayout aufKarteAnzeigen = FindViewById<LinearLayout>(Resource.Id.linearLayout133);
			RelativeLayout kartenlayer = FindViewById<RelativeLayout>(Resource.Id.relativeLayout2);
			TextView ingoreText = FindViewById<TextView>(Resource.Id.textView26);
			kartenlayer.Visibility = ViewStates.Gone;
			aufKarteAnzeigen.Click += (object sender, EventArgs e) =>
			{
				ResetDropButtons(drop);
				kartenlayer.Visibility = ViewStates.Visible;
				ignore_switch.Visibility = ViewStates.Gone;
				ingoreText.Visibility = ViewStates.Gone;
			};
			kartenlayer.Click += (object sender, EventArgs e) =>
			{
				kartenlayer.Visibility = ViewStates.Gone;
				ignore_switch.Visibility = ViewStates.Visible;
				ingoreText.Visibility = ViewStates.Visible;
			};
			//Auf Karte anzeigen
        }


		//Drops auf Karte darstellen ###########################################################
		public void ResetDropButtons(Drop mapdrop)
		{
			
			RelativeLayout maplayout = FindViewById<RelativeLayout>(Resource.Id.maplayout2);
			ImageView kartenlayout = FindViewById<ImageView>(Resource.Id.imageView5);

			maplayout.RemoveAllViews();

			ImageButton drop_button = mapdrop.ToImageButton(this);

			// Position
			float left = ((float)kartenlayout.Width - ((float)1224 / (float)2176) * (float)kartenlayout.Height) / (float)2;
			float scaleX = (float)kartenlayout.Width / (float)1224;
			float scaleY = (float)kartenlayout.Height / (float)2176;

			int[] screen = new int[2];
			kartenlayout.GetLocationOnScreen(screen);
			int screenX = screen[0];
			int screenY = screen[1];
			drop_button.SetX(mapdrop.location.position.X * scaleY - drop_button.Width / 2 - screenX + 0.44f * left);
			drop_button.SetY(mapdrop.location.position.Y * scaleY - drop_button.Height / 2 - screenY);

			maplayout.AddView(drop_button);
		}
		//Drops auf Karte darstellen ENDE###########################################################





    }
}
