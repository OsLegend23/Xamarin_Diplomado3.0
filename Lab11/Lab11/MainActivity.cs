using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Complex Data;
        Validate ValidateData;
        int Counter = 0;
        protected async override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnCreate");
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.StartActivity).Click += (sender, e) =>
            {
                var ActivityIntent = new Android.Content.Intent(this, typeof(SecondActivity));
                StartActivity(ActivityIntent);
            };

            Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");

            if (Data == null)
            {
                // No ha sido almacenado, agregado el fragmento a la activity
                Data = new Complex();
                var FragmentTransaction = FragmentManager.BeginTransaction();
                FragmentTransaction.Add(Data, "Data");
                FragmentTransaction.Commit();
            }

            ValidateData = (Validate)this.FragmentManager.FindFragmentByTag("ValidateData");

            if (ValidateData == null)
            {
                // No ha sido almacenado, agregado el fragmento a la activity
                ValidateData = new Validate();
                var FragmentTransaction = FragmentManager.BeginTransaction();
                await Validate();
                FragmentTransaction.Add(ValidateData, "ValidateData");
                FragmentTransaction.Commit();
            }
            else
            {
                var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
                TextViewValidacion.Text = ValidateData.ToString();
            }

            if (bundle != null)
            {
                Counter = bundle.GetInt("CounterValue", 0);
                Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }

            var ClickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);

            ClickCounter.Text += $"\n{Data.ToString()}";

            ClickCounter.Click += (s, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);

                Data.Real++;
                Data.Imaginary++;
                ClickCounter.Text += $"\n{Data.ToString()}";
            };



        }

        async Task Validate()
        {
            SALLab11.ServiceClient ServiceClient = new SALLab11.ServiceClient();

            string StudentMail = "r.alejandro.aguilar.m@gmail.com";
            string Password = "nemesis@23";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);            

            var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
            TextViewValidacion.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

            ValidateData.Status = Result.Status.ToString();
            ValidateData.Fullname = Result.Fullname;
            ValidateData.Token = Result.Token;
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CounterValue", Counter);
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstanceState");
            base.OnSaveInstanceState(outState);
        }
    }
}

