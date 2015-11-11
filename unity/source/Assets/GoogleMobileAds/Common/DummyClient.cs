using UnityEngine;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
    internal class DummyClient : IGoogleMobileAdsBannerClient, IGoogleMobileAdsInterstitialClient
    {
        private IAdListener listener;
        private bool loaded = false;

        public DummyClient(IAdListener listener)
        {
            //Debug.Log("Created DummyClient");
            this.listener = listener;
        }

        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            //Debug.Log("Dummy CreateBannerView");
        }

        public void LoadAd(AdRequest request)
        {
            //Debug.Log("Dummy LoadAd");
            loaded = false;
            TaskManager.DoSecondsAfter(()=> {
                //Debug.Log("Dummy LoadAd done");
                loaded = true;
                listener.FireAdLoaded();
            }, 1.5f);
        }

        public void ShowBannerView()
        {
            //Debug.Log("Dummy ShowBannerView");
        }

        public void HideBannerView()
        {
            //Debug.Log("Dummy HideBannerView");
        }

        public void DestroyBannerView()
        {
            //Debug.Log("Dummy DestroyBannerView");
        }

        public void CreateInterstitialAd(string adUnitId) {
            //Debug.Log("Dummy CreateIntersitialAd");
        }

        public bool IsLoaded() {
            //Debug.Log("Dummy IsLoaded");
            return loaded;
        }

        public void ShowInterstitial() {
            //Debug.Log("Dummy ShowInterstitial");
#if ADTEST
            listener.FireAdOpened();
            BitMango.NativeInterface.SystemAlert("AdMob.ShowInterstitial", "", "click", "close", (click)=>{
                if(click)
                    listener.FireAdLeftApplication();
                listener.FireAdClosing();
                listener.FireAdClosed();
            });
#else
            listener.FireAdOpened();
            TaskManager.DoSecondsAfter(()=>{
                listener.FireAdClosing();
                listener.FireAdClosed();
            }, 1);
#endif
        }

        public void DestroyInterstitial() {
            //Debug.Log("Dummy DestroyInterstitial");
        }

        public void SetInAppPurchaseHandler(IInAppPurchaseListener listener)
        {
            //Debug.Log("Dummy SetInAppPurchaseParams");
        }

        public static int GetBannerHeightInPixel(AdSize adSize)
        {
            //Debug.Log("Dummy GetBannerHeightInPixel");
            return 60;
        }
    }
}
