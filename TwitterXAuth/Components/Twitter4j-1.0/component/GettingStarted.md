This sample shows how to authorize with the Twitter API and post a status update to your account 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById&lt;Button&gt;(Resource.Id.MyButton);

            ConfigurationBuilder config = new ConfigurationBuilder();
            config.SetOAuthConsumerKey("yourconsumerkeyhere");
            config.SetOAuthConsumerSecret("yourconsumersecrethere");
            config.SetOAuthAccessToken("youracesstokenhere");
            config.SetOAuthAccessTokenSecret("youraccesstokensecrethere");
            config.SetUser("username");
            config.SetPassword("password");

            TwitterFactory factory = new TwitterFactory(config.Build());
            ITwitter twitter = factory.Instance;

            button.Click += delegate 
            { 
                button.Text = string.Format("{0} clicks!", count++);

                // Make sure to run on a background thread to prevent NetworkOnMainThreadException

                ThreadPool.QueueUserWorkItem(state =&gt;
                {
                    try
                    {
                        twitter.UpdateStatus("This is a test");
                    }
                    catch(Java.Lang.Exception ex)
                    {
                        // Catch any exceptions and print out to console
                        Console.WriteLine(ex);
                    }
                });
            };

        }

You can then check your Twitter account and you will the new tweet on your feed.