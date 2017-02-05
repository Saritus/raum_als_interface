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
using System.Threading.Tasks;
using Android.Util;
using System.Threading;

namespace TouchWalkthrough
{
	[Activity(Label = "LoadScreenActivity", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]
	public class LoadScreenActivity : Activity
	{
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            // Lade neue Drops
            DropManager dropmanager = DropManager.Instance;

            dropmanager.loadDrops("drops.xml");
            ImageStorage.Instance.loadImages("images.xml");

            dropmanager.updateDrops();//bringt an der stelle nur 1x und zwar beim start der app was
            dropmanager.sortDrops();

            System.Threading.Thread.Sleep(3000); //Let's wait awhile...
			this.StartActivity(typeof(MainActivity));
		}
	}
}
