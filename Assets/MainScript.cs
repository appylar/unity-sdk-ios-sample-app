using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using AOT;

public class MainScript : MonoBehaviour
{

public delegate void onInitialized();
[DllImport("__Internal")]
private static extern void setOnInitialized(onInitialized callBack);

public delegate void onError(string error);
[DllImport("__Internal")]
private static extern void setOnError(onError callBack);

public delegate void onNoBanner();
[DllImport("__Internal")]
private static extern void setOnNoBanner(onNoBanner callBack);

public delegate void onBannerShown();
[DllImport("__Internal")]
private static extern void setOnBannerShown(onBannerShown callBack);

public delegate void onNoInterstitial();
[DllImport("__Internal")]
private static extern void setOnNoInterstitial(onNoInterstitial callBack);

public delegate void onInterstitialClosed();
[DllImport("__Internal")]
private static extern void setOnInterstitialClosed(onInterstitialClosed callBack);

public delegate void onInterstitialShown();
[DllImport("__Internal")]
private static extern void setOnInterstitialShown(onInterstitialShown callBack);

[DllImport("__Internal")]
static extern void initialize(string appKey, string adTypes, string orientations, bool testMode);

[DllImport("__Internal")]
private static extern void showTopBanner();

[DllImport("__Internal")]
private static extern void showBottomBanner();

[DllImport("__Internal")]
private static extern void showInterstitial();

[DllImport("__Internal")]
private static extern void hideInterstitial();

[DllImport("__Internal")]
private static extern void hideBanner();

public static ScreenOrientation orientation = ScreenOrientation.Portrait;

   
    void Start() {
       setOnInitialized(initialized);
       setOnError(error);
       setOnNoBanner(noBanner);
       setOnBannerShown(bannerShown);
       setOnNoInterstitial(noInterstitial);
       setOnInterstitialClosed(interstitialClosed);
       setOnInterstitialShown(interstitialShown);
    }

    public void InitializeSDK()
    {
      string appKey = "OwDmESooYtY2kNPotIuhiQ";
      string orientations = "portrait landscape";
      string adTypes = "banner interstitial";
      initialize(appKey, adTypes, orientations, true);  
    }

    public void OnPressShowTopBanner()
    {
      showTopBanner();
    }

    public void OnPressShowBottomBanner()
    {
      showBottomBanner();  
    }

    public void OnPressShowInterstitial()
    {
     showInterstitial();
    }

    public void OnPressHideBanner()
    {
       hideBanner();
    }

    [MonoPInvokeCallback(typeof(onInitialized))]
    public static void initialized()
    {
      Debug.Log("onInitialized");
    }

    [MonoPInvokeCallback(typeof(onError))]
    public static void error(string error)
    {
      Debug.Log(error);
    }

    [MonoPInvokeCallback(typeof(onNoBanner))]
    public static void noBanner()
    {
       Debug.Log("onNoBanner()");
    }

    [MonoPInvokeCallback(typeof(onBannerShown))]
    public static void bannerShown()
    {
     Debug.Log("onBannerShown()");
    }

    [MonoPInvokeCallback(typeof(onNoInterstitial))]
    public static void noInterstitial()
    {
    Debug.Log("onNoInterstitial()");
    }


   [MonoPInvokeCallback(typeof(onInterstitialShown))]
    public static void interstitialShown() {
       Debug.Log("onInterstitialShown()");
       orientation = Screen.orientation;
        if (Input.deviceOrientation==DeviceOrientation.Portrait) {
          Screen.orientation = ScreenOrientation.Portrait;
          Debug.Log("Portrait set");

        } else if (Input.deviceOrientation==DeviceOrientation.LandscapeLeft) {
               Screen.orientation = ScreenOrientation.LandscapeLeft;
               Debug.Log("LandscapeLeftSet set");
 
        } else if (Input.deviceOrientation==DeviceOrientation.LandscapeRight) {
                Screen.orientation = ScreenOrientation.LandscapeRight;
                Debug.Log("LandscapeRightSet set");

        }  else if (Input.deviceOrientation==DeviceOrientation.PortraitUpsideDown) {
                Screen.orientation = ScreenOrientation.PortraitUpsideDown;
                Debug.Log("PortraitUpsideDown set");

        } else {
            orientation = Screen.orientation;
            Screen.orientation = orientation;
            Debug.Log("Orientation set");
        }
    }

    [MonoPInvokeCallback(typeof(onInterstitialClosed))]
    public static void interstitialClosed()
    {
       Screen.orientation = ScreenOrientation.AutoRotation;
       Debug.Log("onInterstitialClosed()");
    }

}