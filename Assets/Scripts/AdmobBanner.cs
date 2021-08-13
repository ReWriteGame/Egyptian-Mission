using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobBanner : MonoBehaviour
{
    [SerializeField] private string bannerIdAndroid = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] private string bannerIdIphone = "ca-app-pub-3940256099942544/2934735716";
    [SerializeField] private AdPosition bannerPosition;
    //[SerializeField] private Vector2 bannerSize;


    private BannerView bannerView;
    void Start()
    {
        requestBanner();
    }

    //////////////////////////////////////////////////

    public void requestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = bannerIdAndroid;
#elif UNITY_IPHONE
            string adUnitId = bannerIdIphone;
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, bannerPosition);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

}
