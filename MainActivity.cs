namespace TouchWalkthrough
{
	using System;
    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
	using System.Collections.Generic; //For ListView

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/Icon")]
	public class MainActivity : Activity
	{
		bool history_button_on = false;
		bool filter_button_on = false;

		//For ListView
		private ListView listnames;
		private List<string> itemlist;


        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.Main);

            /*
			//For ListView
			listnames = FindViewById<ListView>(Resource.Id.historyList);

			itemlist = new List<string>();
			itemlist.Add("Item 0");
			itemlist.Add("Item 1");
			itemlist.Add("Item 2");
			itemlist.Add("Item 3");
			itemlist.Add("Item 4");
			 
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,itemlist);
			listnames.Adapter = adapter;

			listnames.ItemClick += Listnames_ItemClick;
			//For ListView ENDE
            */

			//For History-Button
			ImageButton history_button = FindViewById<ImageButton>(Resource.Id.imageButton6);
			LinearLayout showHistoryLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutHistory);

			history_button.Click += (object sender, EventArgs e) =>
			{
				if (history_button_on == false)
				{ 
					history_button.SetImageResource(Resource.Drawable.plus_button);
					showHistoryLayout.Visibility = ViewStates.Visible;
				}
				else {
					history_button.SetImageResource(Resource.Drawable.history_button);
					showHistoryLayout.Visibility = ViewStates.Gone;
				}
			};
			//For History-Button ENDE

			 
			//For Filter-Button
			ImageButton filter_button = FindViewById<ImageButton>(Resource.Id.imageButton2);
			RelativeLayout showFilterLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayoutFilter); //GEHT NICHT?!

			filter_button.Click += (object sender, EventArgs e) =>
			{
				if (filter_button_on == false)//Öffnet Untermenü
				{
					showFilterLayout.Visibility = ViewStates.Visible;
                    filter_button_on = true;

                }
				else {//Schließt Untermenü
					showFilterLayout.Visibility = ViewStates.Gone;
                    filter_button_on = false;
                }
			};
			//For Filter-Button ENDE



        }


		//For ListView
		private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
		}
		//For ListView ENDE


    }
}


