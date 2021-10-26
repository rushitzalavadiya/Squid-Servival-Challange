using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class canvasmanager : MonoBehaviour
{
    public static canvasmanager Instance;

    [Header("Panels")] public GameObject levelWinPanel;

    public GameObject levelFailPanel;

    public GameObject gameplayPanel;

    public int cash;

    public TextMeshProUGUI cashText;

    public TextMeshProUGUI levelText;

    public TextMeshProUGUI shopCashText;

    public List<shopItems> hats;

    public player pS;

    public GameObject ShopPanel;

    private int levelshowNo;

    private int lvlNo;

    public Animator Shopnu;

   

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelshowNo = PlayerPrefs.GetInt("levelshow", 1);
        lvlNo = SceneManager.GetActiveScene().buildIndex;
        cash = PlayerPrefs.GetInt("cash", 0);
        DisplayInfo();
        //AdManager.instance.loadInterstitial();
        //AdManager.instance.showBannerAd();
    }

    public void DisplayInfo()
    {
        cashText.text = cash.ToString();
        shopCashText.text = cash.ToString();
        levelText.text = "LEVEL " + levelshowNo;
    }

    public void Win(float delay)
    {
        Invoke("Winmethod", delay);
    }

    private void Winmethod()
    {
        gameplayPanel.SetActive(false);
        levelWinPanel.SetActive(true);
        if (Gamemanager.Instance.directionLight != null)
        {
            Gamemanager.Instance.directionLight.SetActive(false);
        }
        Gamemanager.Instance.winObject.SetActive(true);
        Debug.Log("showAd");
    }

    public void Fail(float delay)
    {
        Invoke("Failmethod", delay);
    }

    private void Failmethod()
    {
        gameplayPanel.SetActive(false);
        levelFailPanel.SetActive(true);
        Gamemanager.Instance.FailObject.SetActive(true);
        // if ((bool)AdManager.instance)
        // {
        // 	AdManager.instance.showInterstitial();
        // }

        Debug.Log("showAd");
    }

    public void SetHats()
    {
        pS.SetHats();
    }

    public void ShopClose()
    {
        Shopnu.SetTrigger("Close");
        StartCoroutine(Shop());
    }

    public IEnumerator Shop()
    {
        yield return new WaitForSeconds(1f);
        ShopPanel.SetActive(false);
        
    }
    


    public void OnBuyButton()
    {
        if (cash >= 150 && hats.Count != 0)
        {
            var index = Random.Range(0, hats.Count);
            hats[index].Buy();
            cash -= 150;
            PlayerPrefs.SetInt("cash", cash);
            DisplayInfo();
        }
    }

    public void NextLevel()
    {
        if (Gamemanager.Instance.levels == Gamemanager.stages.candy)
        {
            var @int = PlayerPrefs.GetInt("candy", 0);
            @int++;
            PlayerPrefs.SetInt("candy", @int);
        }

        if (lvlNo >= 4)
            lvlNo = 1;
        else
            lvlNo++;
        SceneManager.LoadScene(lvlNo);
        levelshowNo++;
        PlayerPrefs.SetInt("levelshow", levelshowNo);
        PlayerPrefs.SetInt("level", lvlNo);
        cash += 50;
        PlayerPrefs.SetInt("cash", cash);
    }

    public void DubleCoins()
    {
        cash += 100;
        PlayerPrefs.SetInt("cash", cash);
        DisplayInfo();
        
        if (Gamemanager.Instance.levels == Gamemanager.stages.candy)
        {
            var @int = PlayerPrefs.GetInt("candy", 0);
            @int++;
            PlayerPrefs.SetInt("candy", @int);
        }

        if (lvlNo >= 4)
            lvlNo = 1;
        else
            lvlNo++;
        SceneManager.LoadScene(lvlNo);
        levelshowNo++;
        PlayerPrefs.SetInt("levelshow", levelshowNo);
        PlayerPrefs.SetInt("level", lvlNo);
        
    }
    public void VideoButton()
    {
        AddCash();
        // if ((bool)AdManager.instance)
        // {
        // 	AdManager.instance.showRewardVideo();
        // }
    }

    public void AddCash()
    {
        cash += 150;
        PlayerPrefs.SetInt("cash", cash);
        DisplayInfo();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(lvlNo);
    }
}