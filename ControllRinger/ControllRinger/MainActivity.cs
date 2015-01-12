using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace ControllRinger
{
	[Activity (Label = "ControllRinger", MainLauncher = true, Icon = "@drawable/icon")]
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
				AudioManager am = (AudioManager)this.GetSystemService (Context.AudioService);
				//this will put phone to vibration mode. Silent is also available
				am.RingerMode = RingerMode.Vibrate; //do this or the next.. dont execute both :)

				//this will adjust (raise) Ringer volume and show the UI for that also
				//you can control alarm by replacing -> Android.Media.Stream.Alarm and so on.
				am.AdjustSuggestedStreamVolume (Adjust.Raise, Android.Media.Stream.Ring, VolumeNotificationFlags.ShowUi);
			};
		}
	}
}


