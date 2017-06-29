using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = (LinearLayout)ViewGroup.GetChildAt(0);            

            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //MainLayout.AddView(UserNameTextView);
            await Validate();
        }

        async Task Validate()
        {
            SALLab08.ServiceClient ServiceClient = new SALLab08.ServiceClient();

            string StudentMail = "r.alejandro.aguilar.m@gmail.com";
            string Password = "nemesis@23";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);

            var UserNameResultTextView = FindViewById<TextView>(Resource.Id.UserNameResultTextView);
            var StatusResultTextView = FindViewById<TextView>(Resource.Id.StatusResultTextView);
            var TokenResultTextView = FindViewById<TextView>(Resource.Id.TokenResultTextView);

            UserNameResultTextView.Text = Result.Fullname;
            StatusResultTextView.Text = Result.Status.ToString();
            TokenResultTextView.Text = Result.Token;
        }
    }
}

