using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;

namespace TripleMCalc.Core
{
    public class CalculatorViewModel : MvxViewModel
    {//this is version works
       // List<int> numbers = new List<int>(); //initiliaze list that numbers will be added to
       // private int _count = 0;
       // string _numberList;
       // public string NumberList
       // {
       //     get { return _numberList; }
       //     set { _numberList = value; RaisePropertyChanged(() => NumberList); Task task = Task.Run(async () => await Recalculate());} //Call Recalculate every time the list of numbers is updated 
       //     //AsyncContext.Run(Recalculate)
       //     //Recalculate();
       // }



       //private string _responseText; //get and set the response text
       // public string responseText
       // {
       //     get { return _responseText; } 
       //     set { _responseText = value; RaisePropertyChanged(() => responseText); }
       // }

       // float _mean;
       // public float Mean
       // {
       //     get { return _mean; }
       //     set { _mean = value; RaisePropertyChanged(() => Mean); }
       // }

       // float _xmode;
       // public float xMode
       // {
       //     get { return _xmode; }
       //     set { _xmode = value; RaisePropertyChanged(() => xMode); }
       // }

       // float _median;
       // public float Median
       // {
       //     get { return _median; }
       //     set { _median = value; RaisePropertyChanged(() => Median); }
       // }
 

       // async Task Recalculate()
       // {
       //     var numbers = NumberList.Split(',').Select(Int32.Parse).ToList();

       //     numbers.Sort(); //put the list on ascending order
       //     int nc = numbers.Count();
       //     float NumbersSum = numbers.Sum();

       //     Mean = (NumbersSum) / nc; //total the list and divide by the amouhnt of list items


       //     if (await WasItemPurchased("meanmediananswers"))//do these calculations if they have been paid for
       //     {

       //     if (nc % 2 != 0) //if amount of numbers is not even
       //     {
       //         Median = (numbers[nc / 2]); //take the middle number
       //     }
       //     //else //if amount of numbers is even
       //     {
       //         Median = (numbers[(nc - 1) / 2] + numbers[nc / 2]) / 2; //add the two middle numbers and take their average

       //     }

       //     xMode = numbers.GroupBy(n => n). //Group the numbers together by values
       //     OrderByDescending(g => g.Count()).//order them by biggest group to smallest group
       //     Select(g => g.Key).FirstOrDefault(); //choose the first number it will be the one that appeard most often
       //     } //end of if purchased statement 
       // }

        private MvxAsyncCommand _makePurchaseCommand;

        public MvxAsyncCommand MakePurchaseCommand
        {
            get => _makePurchaseCommand;
            set => SetProperty(ref _makePurchaseCommand, value);
        }

        //buy Button Stuff
        public CalculatorViewModel()
        {
            MakePurchaseCommand = new MvxAsyncCommand(ButtonWasPressed);
            Console.WriteLine("words*******************************************************************************************************");
        }

        public async Task ButtonWasPressed()
        {
            //await MakePurchase("meanmediananswers");
           // responseText="Hello";
        }

        //public async Task CheckPurchase()
        //{
        //    await WasItemPurchased("meanmediananswers");

        //}

    //    async Task UpdateResponse(string _string)
    //    {
    //       _count++;
    //        //RaisePropertyChanged(() => responseText);
    //        responseText = responseText + _count + " . " + _string + ".\n\n";
    //    }

    //    public async Task MakePurchase(string productId) 
    //        /*
    //        payload attribute is a special layload that is sent and then returned from the server for additional validation. 
    //        It can be whatever you want it to be, but should be a constant that is used anywhere the payload is used
    //        */
        
    //    {
    //            if (!CrossInAppBilling.IsSupported)
    //            {
    //                await UpdateResponse("Billing not supported");
    //                return;
    //            }
    //            else
    //            {
    //                await UpdateResponse("Billing Supported");
    //            }

    //            var billing = CrossInAppBilling.Current;
    //            try
    //            {
    //                //Connecting to the API.
    //                bool connected = await billing.ConnectAsync(ItemType.InAppPurchase); //ConnectAsync ensures a valid connecion to the app store

    //                if (!connected) //check before calling API tp see if it is supported on the platform where the code is running
    //                {
    //                    await UpdateResponse("We are offline or can't connect, don't try to purchase");
    //                    return;

    //                }
    //                else
    //                {
    //                    await UpdateResponse("Connected, proceeding to purchase");
    //                }
    //                //Getting purchases.
    //            IEnumerable<InAppBillingPurchase> purchased = await billing.GetPurchasesAsync(ItemType.InAppPurchase);

    //            //try to purchase item
    //            if (purchased != null)
    //                {
    //                    foreach (var item in purchased)
    //                    {
    //                        await UpdateResponse("Purchased\n\t\t" + item.ProductId);
    //                    }
    //                }
    //                else
    //                {
    //                    await UpdateResponse("No purchases Yet");
    //                }

    //                //Creating product list and purchasing.
    //                var items = await billing.GetProductInfoAsync(ItemType.InAppPurchase, productId);

    //                foreach (InAppBillingProduct item in items)
    //                {
    //                    string productID = item.ProductId;
    //                    InAppBillingPurchase purchase = await billing.PurchaseAsync(productID, ItemType.InAppPurchase, "devId");
    //                if (purchase == null)
    //                    {
    //                        await UpdateResponse("Error in purchase, can't purchase");
    //                    }
    //                    else if (purchase.State == PurchaseState.Purchased)
    //                    {
    //                        await UpdateResponse("Purchased the product :" + productID);
    //                    }
    //                }
    //            }
    //            catch (InAppBillingPurchaseException purchaseEx)
    //            {
    //                var message = string.Empty;
    //                message = (purchaseEx.PurchaseError).ToString();
    //                await UpdateResponse(message);
    //            }
    //            catch (Exception ex)
    //            {
    //                System.Diagnostics.Debug.WriteLine("Issue connecting: " + ex);
    //                await UpdateResponse(ex.ToString());
    //            }
    //            finally
    //            {
    //                await billing.DisconnectAsync();
    //                await UpdateResponse("Disconnected from the Billing API");
    //            }
    //    }

    //    public async Task<bool> WasItemPurchased(string productId) //calculate whether the item has been purchased or not
    //    {
    //        var billing = CrossInAppBilling.Current;
    //        try
    //        {
    //            var connected = await billing.ConnectAsync(ItemType.InAppPurchase);

    //            if (!connected)
    //            {
    //                //Couldn't connect
    //                return false;
    //            }

    //            //check purchases
    //            var purchases = await billing.GetPurchasesAsync(ItemType.InAppPurchase);

    //            //check for null just incase
    //            if (purchases?.Any(p => p.ProductId == productId) ?? false)
    //            {
    //                //Purchase restored
    //                return true;
    //            }
    //            else
    //            {
    //                //no purchases found
    //                return false;
    //            }
    //        }
    //        catch (InAppBillingPurchaseException purchaseEx)
    //        {
    //            //Billing Exception handle this based on the type
    //            Debug.WriteLine("Error: " + purchaseEx);
    //        }
    //        catch (Exception ex)
    //        {
    //            //Something has gone wrong
    //        }
    //        finally
    //        {
    //            await billing.DisconnectAsync();
    //        }

    //        return false;
    //    }
    }
}

