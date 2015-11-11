using System;

namespace GoogleMobileAds.Api
{
    public interface IInAppPurchaseResult
    {

        string ProductId { get; }
        void RecordPlayBillingResolution(int billingResponseCode);
    }
}
