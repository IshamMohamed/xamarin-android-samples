using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Twitter4j;
using Twitter4j.Auth;
using Twitter4j.Conf;


namespace TwitterXAuth
{
	[Activity (Label = "TwitterXAuth", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Assigning controls
			Button button = FindViewById<Button> (Resource.Id.myButton);
			EditText username = FindViewById<EditText> (Resource.Id.editText1);
			EditText password = FindViewById<EditText> (Resource.Id.editText2);

			// Twitter configuration part
			ConfigurationBuilder TwitterConfig = new ConfigurationBuilder();
			TwitterConfig.SetOAuthConsumerKey("_replace_wit_your_app_consumer_key_");
			TwitterConfig.SetOAuthConsumerSecret ("_replace_wit_your_app_consumer_secret_");
			IConfiguration twiConfigInterface = TwitterConfig.Build ();

			TwitterFactory factory = new TwitterFactory (twiConfigInterface);

			OAuthAuthorization oath = new OAuthAuthorization (twiConfigInterface);

			AccessToken ascTkn = oath.GetOAuthAccessToken (username.Text, password.Text);
			ITwitter twitter = factory.GetInstance(ascTkn);

			button.Click += delegate {
				ThreadPool.QueueUserWorkItem(state =>
					{
						try
						{
							twitter.UpdateStatus("Hello world, Xamarin is exciting.. boom..");
						}
						catch(Exception ed)
						{
							Console.WriteLine(ed.Message);
						}
					}
				);
			};
		}
	}
}


