using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Twitter4j.Conf;
using Twitter4j;
using System.Threading;

namespace Twitter4jSample
{
    [Activity(Label = "Twitter4jSample", MainLauncher = true, Icon = "@drawable/icon")]
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

            // TODO change OAuth keys and tokens and username and password 

            ConfigurationBuilder config = new ConfigurationBuilder();
            config.SetOAuthConsumerKey("YourConsumerKey");
            config.SetOAuthConsumerSecret("YourConsumerSecret");
            config.SetOAuthAccessToken("YourAccessToken");
            config.SetOAuthAccessTokenSecret("YourAccessTokenSecret");
            config.SetUser("YouUsername");
            config.SetPassword("YourPassword");

            TwitterFactory factory = new TwitterFactory(config.Build());
            ITwitter twitter = factory.Instance;

            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
                ThreadPool.QueueUserWorkItem(state =>
                {
                    try
                    {
                        twitter.UpdateStatus("This is a test");
                    }
                    catch (Java.Lang.Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                });
            };
        }
    }
}

