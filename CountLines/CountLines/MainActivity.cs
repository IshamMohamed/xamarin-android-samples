using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Text;

namespace CountLines
{
	[Activity (Label = "CountLines", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			TextView txtview = FindViewById<TextView> (Resource.Id.question);

			button.Click += delegate {
				int height = txtview.Height;
				int scrollY = txtview.ScrollY;
				Layout layout = txtview.Layout;
				int lineCount = layout.GetLineForVertical (scrollY + height)+1;

				Toast.MakeText(this,lineCount.ToString(),ToastLength.Long).Show();
				System.Diagnostics.Debug.WriteLine(lineCount.ToString());
			};
				
		}
			
	}
}


