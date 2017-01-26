
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
        //For ListView
        private ListView listnames;
        private List<string> itemlist;

        //Create Dummy Drops
        //private DropManager dropmanager = DropManager.Instance;
        private List<Drop> droplist = new List<Drop>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.History);
            // Create your application here

            //For ListView
            //dropmanager.updateDrops();
            //droplist = dropmanager.drops;

            listnames = FindViewById<ListView>(Resource.Id.historyList);

            itemlist = new List<string>();

            droplist.ForEach(drop => itemlist.Add(drop.name));

            itemlist.Add("Item 0");
            //itemlist.Add("Item 1");
            //itemlist.Add("Item 2");
            //itemlist.Add("Item 3");
            //itemlist.Add("Item 4");

            //itemlist.Add(droplist[0].getName());
            //itemlist.Add(droplist[1].getName());

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, itemlist);
            listnames.Adapter = adapter;

            listnames.ItemClick += Listnames_ItemClick;
            //For ListView ENDE

            ImageButton history_button2 = FindViewById<ImageButton>(Resource.Id.imageButton122);
            history_button2.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(MainActivity));

            };

        }

        //For ListView ##############################################################
        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
        }
        //For ListView ENDE ##############################################################
    }
}
