using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace NivelApi
{
    [Activity(Label = "Lab07", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            // Create your application here

            var correo = FindViewById<EditText>(Resource.Id.CorreoText);
            var pass = FindViewById<EditText>(Resource.Id.PasswordText);
            var ValidarButton = FindViewById<Button>(Resource.Id.ValdidarButton);
            var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
            TextViewValidacion.Text = string.Empty;

            ValidarButton.Click += async (sender, e) =>
            {
                await Validate(correo.Text, pass.Text);
            };
        }

        async Task Validate(string correo, string pass)
        {
            SALLab07.ServiceClient ServiceClient = new SALLab07.ServiceClient();

            string StudentMail = correo;
            string Password = pass;
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);

            var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
            var texto = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var Builder = new Notification.Builder(this)
                    .SetContentTitle("Validación de actividad")
                    .SetContentText(texto)
                    .SetSmallIcon(Resource.Drawable.Icon);

                Builder.SetCategory(Notification.CategoryMessage);

                var ObjectNotification = Builder.Build();
                var Manager = GetSystemService(NotificationService) as NotificationManager;
                Manager.Notify(0, ObjectNotification);
            }
            else
            {
                TextViewValidacion.Text = texto;
            }


        }
    }
}

