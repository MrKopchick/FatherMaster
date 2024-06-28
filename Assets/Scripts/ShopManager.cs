using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject maxHpButton;
    public GameObject SpeedButton;
    public GameObject healthButton;
    public RectTransform CompleteMessage;
    public RectTransform DiscardMessage;
    public RectTransform AllPurchased;
    public TMP_Text count;
    private int money;
    private AudioSource audioSource;
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] private int price = 50;
    private void Start()
    {
        ShowAllPurchasedMessage();
        UpdateMoney();
        if (PlayerPrefs.GetInt("MaxHP") < 7)
        {
            PlayerPrefs.SetInt("MaxHP", 5);
        }
        if (PlayerPrefs.GetFloat("Speed") < 6)
        { 
            PlayerPrefs.SetFloat("Speed", 5);
        }
        if (PlayerPrefs.GetInt("Health") < 4)
        { 
            PlayerPrefs.SetInt("Health", 3);
        }
        audioSource = GetComponent<AudioSource>();
        DestroyMaxButton();
        DestroySpeedButton();
        DestroyHealthButton();
    }

    public void DestroyMaxButton()
    {
        if (PlayerPrefs.GetInt("MaxHP") > 5)
        { 
            Destroy(maxHpButton); 
            Debug.Log("now its ten and I should destroy it");
        }
    }
    
    public void DestroySpeedButton()
    {
        if (PlayerPrefs.GetFloat("Speed") > 5)
        { 
            Destroy(SpeedButton); 
            Debug.Log("now its ten and I should destroy it");
        }
    }
    
    public void DestroyHealthButton()
    {
        if (PlayerPrefs.GetInt("Health") > 3)
        { 
            Destroy(healthButton); 
            Debug.Log("now its ten and I should destroy it");
        }
    }
    
    public void BuyMaxHp(int newHp)
    {
        if (money >= price)
        {
            int _default = 5;
            PlayerPrefs.SetInt("MaxHP", _default + newHp);
            Debug.Log(PlayerPrefs.GetInt("MaxHP"));
            audioSource.clip = ButtonSound;
            PlayerPrefs.SetInt("Score", money -= price);
            audioSource.Play();
            DestroyMaxButton();
            StartCoroutine(ShowCompleteMessage());
            UpdateMoney();
            PlayerPrefs.SetInt("CountOfPurchase", PlayerPrefs.GetInt("CountOfPurchase") + 1);
            Debug.Log(PlayerPrefs.GetInt("CountOfPurchase"));
        }
        else
        {
            StartCoroutine(ShowDiscardMessage());
        }
    }
    
    
    public void BuySpeed(int newHp)
    {
        if (money >= price)
        {
            int _default = 5;
            PlayerPrefs.SetFloat("Speed", _default + newHp);
            Debug.Log(PlayerPrefs.GetFloat("Speed"));
            PlayerPrefs.SetInt("Score", money -= price);
            audioSource.clip = ButtonSound;
            audioSource.Play();
            DestroySpeedButton();
            StartCoroutine(ShowCompleteMessage());
            UpdateMoney();
            PlayerPrefs.SetInt("CountOfPurchase", PlayerPrefs.GetInt("CountOfPurchase") + 1);
            Debug.Log(PlayerPrefs.GetInt("CountOfPurchase"));
        }
        else
        {
            StartCoroutine(ShowDiscardMessage());
        }
    }
    
    public void BuyStartHealth(int newHp)
    {
        if (money >= price)
        {
            int _default = 3;
            PlayerPrefs.SetInt("Health", _default + newHp);
            Debug.Log(PlayerPrefs.GetInt("Health"));
            PlayerPrefs.SetInt("Score", money -= price);
            audioSource.clip = ButtonSound;
            audioSource.Play();
            DestroyHealthButton();
            StartCoroutine(ShowCompleteMessage());
            UpdateMoney();
            PlayerPrefs.SetInt("CountOfPurchase", PlayerPrefs.GetInt("CountOfPurchase") + 1);
            Debug.Log(PlayerPrefs.GetInt("CountOfPurchase"));
        }
        else
        {
            StartCoroutine(ShowDiscardMessage());
        }
    }

    private void UpdateMoney()
    {
        money = PlayerPrefs.GetInt("Score");
        count.text = "" + PlayerPrefs.GetInt("Score");
    }

    private IEnumerator ShowCompleteMessage()
    {
        CompleteMessage.DOAnchorPosY(500, 0.7f);
        yield return new WaitForSeconds(0.7f);
        CompleteMessage.DOAnchorPosY(0, 0.3f);
    }
    private IEnumerator ShowDiscardMessage()
    {
        DiscardMessage.DOAnchorPosY(500, 0.7f);
        yield return new WaitForSeconds(0.7f);
        DiscardMessage.DOAnchorPosY(0, 0.3f);
    }

    public void AddMoney()
    {
        int _count = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", _count + 50);
        UpdateMoney();
    }
    public void RemoveMoney()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        ShowAllPurchasedMessage();
    }

    private void ShowAllPurchasedMessage()
    {
        if (PlayerPrefs.GetInt("CountOfPurchase") == 3)
        {
            AllPurchased.DOAnchorPosY(500, 0.5f);
        }
    }
}
