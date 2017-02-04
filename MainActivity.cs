namespace TouchWalkthrough
{

    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using System;
    using System.Collections.Generic; //For ListView

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/logo", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        // request codes
        static int HISTORY_REQUEST = 1001;
        static int DROPDETAIL_REQUEST = 1002;
        static int NEWDROP_REQUEST = 1003;

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

            ImageButton aktualisieren = FindViewById<ImageButton>(Resource.Id.imageButton104);
            aktualisieren.Click += (object sender, EventArgs e) =>
            {
                ResetDropButtons();
            };


            //OPEN-HISTORY##############################################################
            ImageButton history_button = FindViewById<ImageButton>(Resource.Id.imageButton6);
            history_button.Click += (object sender, EventArgs e) =>
            {
                StartActivityForResult(typeof(HistoryActivity), HISTORY_REQUEST);
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
                else
                {
                    text1.SetTextColor(Color.Rgb(97, 97, 97));
                    text1.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                    hap1_button.SetImageResource(Resource.Drawable.icon_hap1);
                    hap1_button_on = false;
                }
                ResetDropButtons();
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
                else
                {
                    text2.SetTextColor(Color.Rgb(97, 97, 97));
                    text2.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                    hap2_button.SetImageResource(Resource.Drawable.icon_hap2);
                    hap2_button_on = false;
                }
                ResetDropButtons();
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
                else
                {
                    text3.SetTextColor(Color.Rgb(97, 97, 97));
                    text3.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                    hap3_button.SetImageResource(Resource.Drawable.icon_hap3);
                    hap3_button_on = false;
                }
                ResetDropButtons();
            };
            //For Filter-Button ON/OFF FILTER ENDE###########################################################

            //OPEN CREAT NEW DROP (Plus-Button) ##########################################################
            ImageButton plus_button = FindViewById<ImageButton>(Resource.Id.imageButton1);
            plus_button.Click += (object sender, EventArgs e) =>
            {
                StartActivityForResult(typeof(NewDropActivity), NEWDROP_REQUEST);
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


        //Drops auf Karte darstellen ###########################################################
        public void ResetDropButtons()
        {
            List<Drop> mapDrops = dropmanager.getBuildingDrops(Building.Z);
            //RelativeLayout maplayout = FindViewById<RelativeLayout>(Resource.Id.RelativeLayoutMap);
            RelativeLayout maplayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
            ImageView kartenlayout = FindViewById<ImageView>(Resource.Id.ImageViewKarte);

            maplayout.RemoveAllViews();

            foreach (Drop mapdrop in mapDrops)
            {
                if (mapdrop.ignored)
                    continue;
                if (mapdrop.category == Category.EVENT && hap1_button_on)
                    continue;
                if (mapdrop.category == Category.WARNING && hap2_button_on)
                    continue;
                if (mapdrop.category == Category.VOTE && hap3_button_on)
                    continue;

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

                // Funktion
                drop_button.Click += (object senderobject, EventArgs ea) =>
                {
                    Intent intent = new Intent(this, typeof(DropDetailsActivity));
                    intent.PutExtra("ID", dropmanager.getDropNumber(mapdrop.id));

                    StartActivityForResult(intent, DROPDETAIL_REQUEST);
                };

                maplayout.AddView(drop_button);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            // Check which request we're responding to
            if (requestCode == 0)
            {
                ResetDropButtons();
            }
        }
        //Drops auf Karte darstellen ###########################################################

    }
}