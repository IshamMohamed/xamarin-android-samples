using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;

namespace LightSensor
{
	[Activity (Label = "LightSensor", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, Android.Hardware.ISensorEventListener
	{
		private SensorManager _senMan;
		float lightSensorValue;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Button button = FindViewById<Button> (Resource.Id.myButton);

			_senMan = (SensorManager)GetSystemService (Context.SensorService);
			Sensor sen = _senMan.GetDefaultSensor (SensorType.Light);
			_senMan.RegisterListener (this, sen, Android.Hardware.SensorDelay.Game);

			button.Click += delegate {
				Toast.MakeText(this, sen.Vendor,ToastLength.Long).Show();
			};
		}


		public void OnSensorChanged(SensorEvent s)
		{
			s.Sensor = _senMan.GetDefaultSensor (SensorType.Light);
			lightSensorValue = s.Values [0];
			Toast.MakeText(this, lightSensorValue.ToString("0.00"),ToastLength.Long).Show();
		}

		public void OnAccuracyChanged (Sensor sensor, SensorStatus accuracy)
		{
			//throw new NotImplementedException ();
		}
	}
}