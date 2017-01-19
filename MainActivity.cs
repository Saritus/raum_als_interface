namespace TouchWalkthrough
{
    using System;
    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using System.Collections.Generic; //For ListView

	//Theme = "@android:style/Theme.NoTitleBar"
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/Icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        bool history_button_on = false;
        bool filter_button_on = false;
		bool plus_button_on = false;

        //For ListView
        private ListView listnames;
        private List<string> itemlist;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            
			//For ListView
			/*listnames = FindViewById<ListView>(Resource.Id.historyList);

			itemlist = new List<string>();
			itemlist.Add("Item 0");
			itemlist.Add("Item 1");
			itemlist.Add("Item 2");
			itemlist.Add("Item 3");
			itemlist.Add("Item 4");
			 
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,itemlist);
			listnames.Adapter = adapter;

			listnames.ItemClick += Listnames_ItemClick;*/
			//For ListView ENDE
            

            //For History-Button ##############################################################
            ImageButton history_button = FindViewById<ImageButton>(Resource.Id.imageButton6);
            history_button.Click += (object sender, EventArgs e) =>
            {
                if (history_button_on == false)
                {
                    SetContentView(Resource.Layout.History);
                    history_button_on = true;
                } 
                else
                { 
                    SetContentView(Resource.Layout.Main);
                    history_button_on = false;
                }
            };
            //For History-Button ENDE ##############################################################


            //For Filter-Button ##############################################################
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
            //For Filter-Button ENDE ##############################################################



			//For Plus-Button ##############################################################
			ImageButton plus_button = FindViewById<ImageButton>(Resource.Id.imageButton1);
			plus_button.Click += (object sender, EventArgs e) =>
			{
				if (plus_button_on == false)//Öffnet Untermenü
				{
					SetContentView(Resource.Layout.Plus_Menue);
					plus_button_on = true;
				}
				else
				{//Schließt Untermenü
					SetContentView(Resource.Layout.Main);
					plus_button_on = false;
				}
			};
			//For Plus-Button ENDE ##############################################################



			 

	}

		//Use Hardware-Back-Button ##############################################################
		public override void OnBackPressed()
		{
			//base.OnBackPressed();
			if (plus_button_on == true)
			{ //gehe zurück auf Main-Screen
				plus_button_on = false;
				SetContentView(Resource.Layout.Main);
			}

			if (history_button_on == true)
			{//gehe zurück auf Main-Screen
				history_button_on = false;
				//SetContentView(Resource.Layout.Main);
			}

		}
		//Use Hardware-Back-Button ENDE ##############################################################


        //For ListView ##############################################################
        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
        }
        //For ListView ENDE ##############################################################


    }
}


