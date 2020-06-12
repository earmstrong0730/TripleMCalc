using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;


using MvvmCross.Droid.Support.V7.AppCompat;
using System.Threading.Tasks;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using TripleMCalc.Core;

namespace TripleMCalc.Droid
{
	[Activity(Label = "Calculator", MainLauncher=true)]
	public class Calculator : MvxAppCompatActivity<CalculatorViewModel>
    {
		protected override void OnCreate(Bundle savedInstanceState)
		{
            
            base.OnCreate(savedInstanceState);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this; //get access to current android activity.

            // Create your application here
        }
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.CalculatorLayout);
        }


        //this might only be for Xamarin forms?? Refer to https://devblogs.microsoft.com/xamarin/integrating-in-app-purchases-in-mobile-apps/

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }

    }
}
