using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Gcm.Client;
using Android.Content;

namespace App5.Droid
{
	[Activity(Label = "App5", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			//啟動服務
			StartService(new Intent(this, typeof(TimerService)));
		}

	}
}
