#if UNITY_ANDROID

using UnityEngine;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Android
{
    internal class InAppPurchaseListener : AndroidJavaProxy
    {
        private IInAppPurchaseListener listener;
        internal InAppPurchaseListener(IInAppPurchaseListener listener)
            : base(Utils.InAppPurchaseListenerClassName)
        {
            this.listener = listener;
        }

        void onInAppPurchaseRequested(AndroidJavaObject result) {
            InAppPurchaseResult wrappedResult = new InAppPurchaseResult(result);
            listener.FireOnInAppPurchaseRequested(wrappedResult);
        }
    }
}

#endif
