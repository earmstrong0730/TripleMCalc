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

namespace TripleMCalc.Droid
{
	[Activity(Label = "Calculator", MainLauncher=true)]
	public class Calculator : MvxActivity 
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
           

            // Create your application here
        }
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.CalculatorLayout);
        }
    }

    //public async Task<bool> MakePurchase()
    //{
    //    if (!CrossInAppBilling.IsSupported)
    //        return false;

    //    try
    //    {
    //        var billing = CrossInAppBilling.Current;
    //        var connected = await billing.ConnectAsync(ItemType.InAppPurchase);
    //        if (!connected)
    //            return false;

    //        //make additional billing calls

    //    }
    //    finally
    //    {
    //        await billing.DisconnectAsync();
    //    }
    //}
}
