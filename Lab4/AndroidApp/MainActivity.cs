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

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            /** Creamos la instancia del código compartido y le inyectamos la dependencia. */
            var Validator = new PCLProject.AppValidator(new AndroidDialog(this));

            /** Aquí prodríamos establecer los valores de las propiedades
             * Email, Password y Device */

            Validator.Email = "r.alejandro.aguilar.m@gmail.com";
            Validator.Password = "nemesis@23";
            Validator.Device = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            // Realizamos la validación
            Validator.Validate();
        }
    }
}

