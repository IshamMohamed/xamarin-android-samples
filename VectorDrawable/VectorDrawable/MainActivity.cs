using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VectorDrawable
{
    [Activity(Label = "VectorDrawable", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            ImageButton playBtn = FindViewById<ImageButton>(Resource.Id.imageButton1);

            button.Click += delegate 
            {
                Toast.MakeText(this, "Dont press me!!", ToastLength.Long).Show();
            };

            playBtn.LongClickable = true;
            playBtn.LongClick += delegate
            {
                Toast.MakeText(this, "Looooong click", ToastLength.Long).Show();
            };

            playBtn.Click += delegate
            {
                Toast.MakeText(this, "Click", ToastLength.Long).Show();
            };
        }
    }
}

