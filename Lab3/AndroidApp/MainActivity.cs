using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var Helper = new SharedProject.MySharedCode();
            new AlertDialog.Builder(this).SetMessage(Helper.GetFilePath("demo.dat")).Show();
            Validate();
        }

        private async void Validate()
        {
            SALLab03.ServiceClient ServiceClient = new SALLab03.ServiceClient();

            string StudentMail = "r.alejandro.aguilar.m@gmail.com";
            string Password = "nemesis@23";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            //SALLab03.ResultInfo Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);
            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
    }
}

