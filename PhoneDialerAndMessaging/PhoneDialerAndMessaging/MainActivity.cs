using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony.Gsm;

namespace PhoneDialerAndMessaging
{
	[Activity (Label = "PhoneDialerAndMessaging", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button buttonPhoneDialer = FindViewById<Button> (Resource.Id.buttonPhoneDialer);
			Button buttonSendSMS = FindViewById<Button> (Resource.Id.buttonSendSMS);
			Button buttonSendEmail = FindViewById<Button> (Resource.Id.buttonSendEmail);

			EditText editTextPhoneNumber = FindViewById<EditText> (Resource.Id.editTextPhoneNumber);
			EditText editTextMessageBody = FindViewById<EditText> (Resource.Id.editTextMessageBody);
			EditText editTextEmailAddress = FindViewById<EditText> (Resource.Id.editTextEmailAddress);
			EditText editTextEmailBody = FindViewById<EditText> (Resource.Id.editTextEmailBody);

			var phoneNumber = editTextPhoneNumber.Text;
			var smsBody = editTextMessageBody.Text;
			var addressToEmail = editTextEmailAddress.Text;
			var emailBody = editTextEmailBody.Text;

			// Add the CALL_PHONE permission to the android manifest.
			buttonPhoneDialer.Click += delegate {
				var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));
				var intent = new Intent (Intent.ActionView, uri); 
				StartActivity (intent); 
			};

			// Click event of Send SMS button will NOT launch the SMS intent but will send SMS.
			buttonSendSMS.Click += delegate {
				SmsManager.Default.SendTextMessage (phoneNumber, null, smsBody, null, null);
			};

			// Long click event of Send SMS button will launch SMS intent to send SMS.
			buttonSendSMS.LongClick+= delegate {
				var smsUri = Android.Net.Uri.Parse(string.Format("smsto:{0}",phoneNumber));
				var smsIntent = new Intent (Intent.ActionSendto, smsUri);
				smsIntent.PutExtra ("sms_body", smsBody);  
				StartActivity (smsIntent);
			};

			// Email
			buttonSendEmail.Click += delegate {
				var email = new Intent (Android.Content.Intent.ActionSend);

				email.PutExtra(Android.Content.Intent.ExtraEmail, new string[]{addressToEmail});
				// To add CCs
				// email.PutExtra(Android.Content.Intent.ExtraCc, new string[]{addressToEmail});
				// To add BCCs
				// email.PutExtra(Android.Content.Intent.ExtraBcc, new string[]{addressToEmail});

				email.PutExtra(Android.Content.Intent.ExtraSubject,"Replace Subject here");

				email.PutExtra(Android.Content.Intent.ExtraText, emailBody);

				// This will set mime type of the Email
				email.SetType("message/rfc822");

				StartActivity(email);
			};
		}
	}
}


