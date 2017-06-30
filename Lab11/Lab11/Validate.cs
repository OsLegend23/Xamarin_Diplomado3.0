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

namespace Lab11
{
    public class Validate : Fragment
    {
        public string Status { get; set; }
        public string Fullname { get; set; }
        public string Token { get; set; }

        public override string ToString()
        {
            return $"{Status}\n{Fullname}\n{Token}";
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }
    }
}