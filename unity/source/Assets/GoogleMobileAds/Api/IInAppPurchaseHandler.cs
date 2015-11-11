using System;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
    public interface IInAppPurchaseHandler
    {
        void OnInAppPurchaseRequested(IInAppPurchaseResult inAppPurchase);
    }
}
