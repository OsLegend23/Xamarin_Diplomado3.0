using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace PhoneApp
{
    [Activity(Label = "Validar actividad", Theme = "@android:style/Theme.Holo")]
    public class ValidationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validacion);
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
            SALLab06.ServiceClient ServiceClient = new SALLab06.ServiceClient();

            string StudentMail = correo;
            string Password = pass;
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);

            var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
            TextViewValidacion.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }
    }
}