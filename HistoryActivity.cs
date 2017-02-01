
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
    [Activity(Label = "HistoryActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class HistoryActivity : Activity
    {
        DropManager dropmanager = DropManager.Instance;

        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeScreen);
            // Create your application here

            dropmanager.updateDrops();

            listView = FindViewById<ListView>(Resource.Id.List);

            dropmanager.drops.ForEach(drop => tableItems.Add(drop.ToTableItem()));

            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;

        }
		 
        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView2 = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Heading);


			//gebe Daten des drops an Activity DropDetailsActivity.cs weiter... ID des drops reicht eigentlich oder?
			Intent intent = new Intent(this, typeof(DropDetailsActivity));
			intent.PutExtra("MyData", "ID des drops");
			StartActivity(intent);
			//gebe Daten des drops an Activity DropDetailsActivity.cs weiter... ENDE

            //StartActivity(typeof(DropDetailsActivity));
        }
    }
}
