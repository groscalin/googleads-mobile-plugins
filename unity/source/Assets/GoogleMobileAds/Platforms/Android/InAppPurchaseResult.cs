#if UNITY_ANDROID

using UnityEngine;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Android
{
    internal class InAppPurchaseResult : IInAppPurchaseResult
    {
        private UnityEngine.AndroidJavaObject result;
        public InAppPurchaseResult(AndroidJavaObject result)
        {
            this.result = result;
        }

        public string ProductId {
            get { return result.Call<string>("getProductId"); }
        }

        public void RecordPlayBillingResolution(int billingResponseCode){
            result.Call("recordPlayBillingResolution", billingResponseCode);
        }
    }
}

#endif
