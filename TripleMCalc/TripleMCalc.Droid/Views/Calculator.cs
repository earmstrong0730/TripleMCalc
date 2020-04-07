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

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }



        //trying this stuff out     Not sure if this is where It belongs?

        private int _count = 0;
        private void UpdateResponse(string _string)
        {
            _count++;
            //responce_text.Text = responce_text.Text + _count + " . " + _string + ".\n\n";
        }

        private async void MakePurchase()
        {
            if (!CrossInAppBilling.IsSupported)
            {
                UpdateResponse("Billing not supported");
                return;
            }
            else
            {
                UpdateResponse("Billing Supported");
            }

            var billing = CrossInAppBilling.Current;
            var productIds = new string[] { "billing_test_product_1", "billing_test_product_2" };
            try
            {
                //Connecting to the API.
                bool connected = await billing.ConnectAsync(ItemType.InAppPurchase);

                if (!connected)
                {
                    UpdateResponse("We are offline or can't connect, don't try to purchase");
                    return;
                }
                else
                {
                    UpdateResponse("Connected, proceeding to purchase");
                }

                //Getting purchases.
                IEnumerable<InAppBillingPurchase> purchased = await billing.GetPurchasesAsync(ItemType.InAppPurchase);
                if (purchased != null)
                {
                    foreach (var item in purchased)
                    {
                        UpdateResponse("Purchased\n\t\t" + item.ProductId);
                    }
                }
                else
                {
                    UpdateResponse("No purchases Yet");
                }

                //Creating product list and purchasing.
                var items = await billing.GetProductInfoAsync(ItemType.InAppPurchase, productIds);

                foreach (InAppBillingProduct item in items)
                {
                    string productID = item.ProductId;
                    InAppBillingPurchase purchase = await billing.PurchaseAsync(productID, ItemType.InAppPurchase, "devId");
                    if (purchase == null)
                    {
                        UpdateResponse("Error in purchase, can't purchase");
                    }
                    else if (purchase.State == PurchaseState.Purchased)
                    {
                        UpdateResponse("Purchased the product :" + productID);
                    }
                }
            }
            catch (InAppBillingPurchaseException purchaseEx)
            {
                var message = string.Empty;
                message = (purchaseEx.PurchaseError).ToString();
                UpdateResponse(message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Issue connecting: " + ex);
                UpdateResponse(ex.ToString());
            }
            finally
            {
                await billing.DisconnectAsync();
                UpdateResponse("Disconnected from the Billing API");
            }

        }

    }

    //public async Task<bool> MakePurchase()////////////////////////////////////////ask hinckley about this
    //{
    //    if (!CrossInAppBilling.IsSupported)
    //        return false;

    //    var billing = CrossInAppBilling.Current;

    //    try
    //    {
            
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
