using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace RaysHotDogs
{
    [Activity(Label = "RaysHotDogs", Theme = "@style/AppTheme", MainLauncher = true)]
    // public class MainActivity : Activity { }
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HotDogDetailView);
            //activity_main is defined as an integer - keypt in Resource.Designer.cs
            // the resource value is mapped by activity_main


            //Button button = FindViewById<Button>(Resource.Id.button);
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}