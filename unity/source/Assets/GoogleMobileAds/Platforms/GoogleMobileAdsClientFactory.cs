using System;
using UnityEngine;
using GoogleMobileAds.Common;
using GoogleMobileAds.Api;

namespace GoogleMobileAds
{
    internal class GoogleMobileAdsClientFactory
    {
        internal static IGoogleMobileAdsBannerClient GetGoogleMobileAdsBannerClient(
                IAdListener listener)
        {
            #if UNITY_EDITOR
                // Testing UNITY_EDITOR first because the editor also responds to the currently
                // selected platform.
                return new GoogleMobileAds.Common.DummyClient(listener);
            #elif UNITY_ANDROID
                if(BitMango.Profile.IsDummyAD)
                    return new GoogleMobileAds.Common.DummyClient(listener);
                else
                    return new GoogleMobileAds.Android.AndroidBannerClient(listener);
            #elif UNITY_IPHONE
                if(BitMango.Profile.IsDummyAD)
                    return new GoogleMobileAds.Common.DummyClient(listener);
                else
                    return new GoogleMobileAds.iOS.IOSBannerClient(listener);
            #else
                return new GoogleMobileAds.Common.DummyClient(listener);
            #endif
        }

        internal static IGoogleMobileAdsInterstitialClient GetGoogleMobileAdsInterstitialClient(
                IAdListener listener)
        {
            #if UNITY_EDITOR
                // Testing UNITY_EDITOR first because the editor also responds to the currently
                // selected platform.
                return new GoogleMobileAds.Common.DummyClient(listener);
            #elif UNITY_ANDROID
                if(BitMango.Profile.IsDummyAD)
                    return new GoogleMobileAds.Common.DummyClient(listener);
                else
                    return new GoogleMobileAds.Android.AndroidInterstitialClient(listener);
            #elif UNITY_IPHONE
                if(BitMango.Profile.IsDummyAD)
                    return new GoogleMobileAds.Common.DummyClient(listener);
                else
                    return new GoogleMobileAds.iOS.IOSInterstitialClient(listener);
            #else
                return new GoogleMobileAds.Common.DummyClient(listener);
            #endif
        }

        internal static int GetBannerHeightInPixel (AdSize adSize)
        {
            #if UNITY_EDITOR
                return GoogleMobileAds.Common.DummyClient.GetBannerHeightInPixel(adSize);
            #elif UNITY_ANDROID
                if(BitMango.Profile.IsDummyAD)
                    return GoogleMobileAds.Common.DummyClient.GetBannerHeightInPixel(adSize);
                else
                    return GoogleMobileAds.Android.AndroidBannerClient.GetBannerHeightInPixel(adSize);
            #elif UNITY_IPHONE
                if(BitMango.Profile.IsDummyAD)
                    return GoogleMobileAds.Common.DummyClient.GetBannerHeightInPixel(adSize);
                else
                    return GoogleMobileAds.iOS.IOSBannerClient.GetBannerHeightInPixel(adSize);
            #else
                if(BitMango.Profile.IsDummyAD)
                    return GoogleMobileAds.Common.DummyClient.GetBannerHeightInPixel(adSize);
                else
                    return GoogleMobileAds.Common.DummyClient.GetBannerHeightInPixel(adSize);
            #endif
        }
        
    }
}
