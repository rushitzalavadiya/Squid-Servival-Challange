// using GoogleMobileAds.Api;
// using System;
// using UnityEngine;
//
// public class AdManager : MonoBehaviour
// {
// 	public static AdManager instance;
//
// 	[Header("Admob Id----")]
// 	public string bannerAdId;
//
// 	[Header("Admob Id----")]
// 	public string interstitialAdId;
//
// 	[Header("Admob Id----")]
// 	public string rewardVideoAdId;
//
// 	[Header("BannerPos----")]
// 	public bool isOnTop;
//
// 	private RewardedAd rewardedAd;
//
// 	private static BannerView bannerView;
//
// 	private static InterstitialAd interstitial;
//
// 	private void Start()
// 	{
// 		base.gameObject.name = "AdManager";
// 		loadrewardedAd();
// 	}
//
// 	public void loadrewardedAd()
// 	{
// 		rewardedAd = new RewardedAd(rewardVideoAdId);
// 		rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
// 		rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
// 		rewardedAd.OnAdOpening += HandleRewardedAdOpening;
// 		rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
// 		rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
// 		rewardedAd.OnAdClosed += HandleRewardedAdClosed;
// 		AdRequest request = new AdRequest.Builder().Build();
// 		rewardedAd.LoadAd(request);
// 	}
//
// 	public void HandleRewardedAdLoaded(object sender, EventArgs args)
// 	{
// 		MonoBehaviour.print("HandleRewardedAdLoaded event received");
// 	}
//
// 	public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
// 	{
// 		MonoBehaviour.print("HandleRewardedAdFailedToLoad event received with message: " + args.Message);
// 		loadrewardedAd();
// 	}
//
// 	public void HandleRewardedAdOpening(object sender, EventArgs args)
// 	{
// 		MonoBehaviour.print("HandleRewardedAdOpening event received");
// 	}
//
// 	public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
// 	{
// 		MonoBehaviour.print("HandleRewardedAdFailedToShow event received with message: " + args.Message);
// 	}
//
// 	public void HandleRewardedAdClosed(object sender, EventArgs args)
// 	{
// 		MonoBehaviour.print("HandleRewardedAdClosed event received");
// 	}
//
// 	public void HandleUserEarnedReward(object sender, Reward args)
// 	{
// 		string type = args.Type;
// 		MonoBehaviour.print("HandleRewardedAdRewarded event received for " + args.Amount.ToString() + " " + type);
// 		
// 		loadrewardedAd();
// 	}
//
// 	private void Awake()
// 	{
// 		if ((bool)instance)
// 		{
// 			UnityEngine.Object.DestroyImmediate(base.gameObject);
// 			return;
// 		}
// 		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
// 		instance = this;
// 	}
//
// 	public void showBannerAd()
// 	{
// 		if (isOnTop)
// 		{
// 			if (bannerView != null)
// 			{
// 				UnityEngine.Debug.Log("from here");
// 				bannerView.Destroy();
// 			}
// 			bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);
// 			AdRequest request = new AdRequest.Builder().Build();
// 			bannerView.LoadAd(request);
// 		}
// 		else
// 		{
// 			if (bannerView != null)
// 			{
// 				UnityEngine.Debug.Log("from here");
// 				bannerView.Destroy();
// 			}
// 			bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Bottom);
// 			AdRequest request2 = new AdRequest.Builder().Build();
// 			bannerView.LoadAd(request2);
// 		}
// 		UnityEngine.Debug.Log("booom ");
// 	}
//
// 	public void loadInterstitial()
// 	{
// 		interstitial = new InterstitialAd(interstitialAdId);
// 		AdRequest request = new AdRequest.Builder().Build();
// 		interstitial.LoadAd(request);
// 	}
//
// 	public void showInterstitial()
// 	{
// 		if (interstitial.IsLoaded())
// 		{
// 			interstitial.Show();
// 		}
// 	}
//
// 	public void hideBannerAd()
// 	{
// 		bannerView.Hide();
// 	}
//
// 	public void showRewardVideo()
// 	{
// 		if (rewardedAd.IsLoaded())
// 		{
// 			rewardedAd.Show();
// 		}
// 	}
// }

