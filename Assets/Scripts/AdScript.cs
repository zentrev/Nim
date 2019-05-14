using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdScript : MonoBehaviour
{
    InterstitialAd myAd = null;
    private void Start()
    {
        AdScript[] temp = GameObject.FindObjectsOfType<AdScript>();

        if(temp.Length > 1)
        {
            Destroy(gameObject);
        }

        string appId = "ca-app-pub-8549494723516066~2991453367";
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        InterstitialAd myAd = new InterstitialAd("ca-app-pub-8549494723516066/2406319370");
        DontDestroyOnLoad(gameObject);
    }

    public void LoadAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        myAd.LoadAd(request);
    }

    public void ShowAd()
    {
        if (myAd.IsLoaded())
        {
            myAd.Show();
        }
        LoadAd();
    }

}
