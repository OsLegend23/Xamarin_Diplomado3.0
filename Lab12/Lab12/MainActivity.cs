using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;
using Android.Graphics;
using System.Threading.Tasks;

namespace Lab12
{
    [Activity(Label = "designer", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            //var MyLayout = new MyViewGroup(this);
            //SetContentView(MyLayout);
            var ListColors = FindViewById<ListView>(Resource.Id.ColorsListView);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(this, 
                Resource.Layout.ListItem, 
                Resource.Id.NameColorText,
                Resource.Id.CodeColorText,
                Resource.Id.ImageColor);

            await Validate();
        }

        async Task Validate()
        {
            SALLab12.ServiceClient ServiceClient = new SALLab12.ServiceClient();

            string StudentMail = "r.alejandro.aguilar.m@gmail.com";
            string Password = "nemesis@23";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentMail, Password, myDevice);

            var TextViewValidacion = FindViewById<TextView>(Resource.Id.ValidacionTextView);
            TextViewValidacion.Text = $"{Result.Status}\n{Result.FullName}\n{Result.Token}";
        }
    }

    class MyViewGroup: ViewGroup
    {
        Context ViewGRoupContext;
        public MyViewGroup(Context context) : base(context)
        {
            this.ViewGRoupContext = context;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            // Agregando un nuevo layout.
            this.SetBackgroundColor(Color.Fuchsia);
            var MyView = new View(ViewGRoupContext);
            MyView.SetBackgroundColor(Color.Blue);
            MyView.Layout(20, 20, 150, 150);
            AddView(MyView);

        }
    }
}

