
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

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

            listView = FindViewById<ListView>(Resource.Id.List);

            dropmanager.getDrops().ForEach(drop => tableItems.Add(drop.ToTableItem()));

            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;

        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView2 = sender as ListView;
            var t = tableItems[e.Position];

            //gebe Daten des drops an Activity DropDetailsActivity.cs weiter... ID des drops reicht eigentlich oder?
            Intent intent = new Intent(this, typeof(DropDetailsActivity));
            intent.PutExtra("ID", t.id.ToString());
            StartActivity(intent);
            //gebe Daten des drops an Activity DropDetailsActivity.cs weiter... ENDE

            //StartActivity(typeof(DropDetailsActivity));
        }
    }
}
