
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

			listView = FindViewById<ListView>(Resource.Id.List);

			tableItems.Add(new TableItem() { Heading = "Ausstellung Architektur", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap1 });
			tableItems.Add(new TableItem() { Heading = "Party Semesterstart", SubHeading = "Gebäude Z103; 13.02.2017", ImageResourceId = Resource.Drawable.icon_hap2 });
			tableItems.Add(new TableItem() { Heading = "Grillen Fak. Informatik", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap3 });
			tableItems.Add(new TableItem() { Heading = "Tag der offenen Tür", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap1 });
			tableItems.Add(new TableItem() { Heading = "Seminar EWZ", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap3 });
			tableItems.Add(new TableItem() { Heading = "Feierliche Immatrikulation", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap2 });
			tableItems.Add(new TableItem() { Heading = "Ausstellung Architektur", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap1 });
			tableItems.Add(new TableItem() { Heading = "Party Semesterstart", SubHeading = "Gebäude Z103; 13.02.2017", ImageResourceId = Resource.Drawable.icon_hap2 });
			tableItems.Add(new TableItem() { Heading = "Grillen Fak. Informatik", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap3 });
			tableItems.Add(new TableItem() { Heading = "Tag der offenen Tür", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap1 });
			tableItems.Add(new TableItem() { Heading = "Seminar EWZ", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap3 });
			tableItems.Add(new TableItem() { Heading = "Feierliche Immatrikulation", SubHeading = "Gebäude Z902; 09.02.2017", ImageResourceId = Resource.Drawable.icon_hap2 });

			listView.Adapter = new HomeScreenAdapter(this, tableItems);

			listView.ItemClick += OnListItemClick;
			 
        }

         protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			var listView2 = sender as ListView;
			var t = tableItems[e.Position];
			Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
			Console.WriteLine("Clicked on " + t.Heading);

			StartActivity(typeof(DropDetailsActivity));
		}
    }
}
