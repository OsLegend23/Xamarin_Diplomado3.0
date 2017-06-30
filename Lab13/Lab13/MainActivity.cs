using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ButtonImage = FindViewById<ImageButton>(Resource.Id.imageButton1);

            ButtonImage.Click += async (s, e) =>
            {
                await Validar();
            };
            
        }

        async Task Validar()
        {
            var Client = new SALLab13.ServiceClient();
            string Email = "r.alejandro.aguilar.m@gmail.com";
            string Pass = "nemesis@23";
            var Result = await Client.ValidateAsync(this, Email, Pass);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
            Alert.SetButton("OK", (s, e) => { });
            Alert.Show();
        }
    }
}

