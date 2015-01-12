using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BatteryPercentage
{
	[Activity (Label = "BatteryPercentage", MainLauncher = true, Icon = "@drawable/icon")]
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
			
			button.Click += delegate {
				var filter  = new IntentFilter(Intent.ActionBatteryChanged);
				var battery = RegisterReceiver(null, filter);
				int level   = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
				int scale   = battery.GetIntExtra(BatteryManager.ExtraScale, -1);

				int level_0_to_100 = (int)System.Math.Floor (level * 100D / scale);
				Toast.MakeText(this,bHealth.ToString(),ToastLength.Long).Show()
			};
		}
	}
}


