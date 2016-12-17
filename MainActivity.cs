namespace TouchWalkthrough
{
	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Views;
	using Android.Widget;


    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : Activity
	{
        bool plus_button_on = false;
        bool filter_button_on = false;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            //SetContentView(Resource.Layout.Main); 
            //View v = new GestureRecognizerView(this);
            //SetContentView(v);


            //Versuch 1:
            View v = new GestureRecognizerView(this);
            LinearLayout karte = new LinearLayout(this);
            LinearLayout.LayoutParams linearLayoutParams2 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
            LinearLayout.LayoutParams.WrapContent, 3.0F);
            LinearLayout.LayoutParams linearLayoutParams1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
            LinearLayout.LayoutParams.WrapContent, 1.0F);
            karte.LayoutParameters = linearLayoutParams1;
            v.LayoutParameters = linearLayoutParams2;
            karte.AddView(v);
            SetContentView(karte);






            /*VERSUCH 2:
            View v = new GestureRecognizerView(this);
            //LinearLayout layout = FindViewById<LinearLayout>(Resource.Layout.Main);
            LinearLayout l = new LinearLayout(this);
            l.AddView(v);
            LinearLayout.LayoutParams linearLayoutParams2 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
            LinearLayout.LayoutParams.WrapContent,3.0F);
            l.LayoutParameters = linearLayoutParams2;
            LinearLayout mainlayout = new LinearLayout(this);
            LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent,
            LinearLayout.LayoutParams.FillParent,1.0F);
            mainlayout.LayoutParameters = linearLayoutParams;

            mainlayout.AddView(l);
            //l.AddView(layout);
            SetContentView(mainlayout);*/



            /* VERSUCH 3:
            LinearLayout linearLayout = new LinearLayout(this);
            LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent,
            LinearLayout.LayoutParams.FillParent);
            linearLayoutParams.SetMargins(0, 0, 0, 0);
            linearLayout.LayoutParameters = linearLayoutParams;

            Button plus_test = FindViewById<Button>(Resource.Id.Button_plus);
            plus_test.SetBackgroundResource(Resource.Drawable.plus_button_normal);

            linearLayout.AddView(plus_test);
            SetContentView(linearLayout);*/















        }
    }
}


