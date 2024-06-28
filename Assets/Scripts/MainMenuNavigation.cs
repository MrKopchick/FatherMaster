using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class MainMenuNavigation : MonoBehaviour
{
    [SerializeField] private RectTransform Buttons;
    [SerializeField] private RectTransform Brand;
    [SerializeField] private RectTransform PausePanel;
    [SerializeField] private RectTransform Shop;
    [SerializeField] private TMP_Text Random_Text;
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] private Transform Player;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Brand.DOAnchorPosY(-297.2134f, 0.7f);
        Buttons.DOAnchorPosY(0, 0.7f);
    }

    public void StartToPlay()
    {
        StartCoroutine(StartPlay());
    }

    private IEnumerator StartPlay()
    {
        
        audioSource.clip = ButtonSound;
        audioSource.Play();
        Brand.DOAnchorPosY(0, 0.1f);
        Buttons.DOAnchorPosY(-2000, 0.1f);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(1);
    }
    
    public void PauseIntro()
    {
        StartCoroutine(PauseIntroCorot());
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            Random_Text.text = "Batka is coming...";
        }
        if(random == 1)
        {
            Random_Text.text = "Don't delay Batka...";
        }
        else
        {
            Random_Text.text = "Batka is hungry....";
        }
    }
    public void PauseOutro()
    {
        StartCoroutine(PauseOutroCorot());
    }

    public void GoMenu()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
        SceneManager.LoadScene("Menu");
    }

    public void ShopIntro()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
        Brand.DOAnchorPosY(2000f, 0.7f);
        Buttons.DOAnchorPosY(-5000, 0.7f);
        Shop.DOAnchorPosY(0, 0.7f);
        Player.DOMoveY(-10, 0.8f);
    }
    public void ShopOutro()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
        Brand.DOAnchorPosY(-297.2134f, 0.7f);
        Buttons.DOAnchorPosY(0, 0.7f);
        Shop.DOAnchorPosY(-5000f, 0.7f);
        Player.DOMoveY(1, 0.8f);
    }

    private IEnumerator PauseIntroCorot()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
    
        PausePanel.DOAnchorPosY(0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        yield return null;
    }
    
    private IEnumerator PauseOutroCorot()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
        Time.timeScale = 1;
        PausePanel.DOAnchorPosY( 5000, 1);
        yield return null;
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            Debug.Log("SceneCompleted: " + scene.name);
            audioSource = gameObject.GetComponent<AudioSource>();
            StartCoroutine(GeneralSceneLoad());
        }
    }

    private IEnumerator GeneralSceneLoad()
    {
        yield return new WaitForSeconds(0.3f);
        Buttons.DOAnchorPosY(0, 0.7f); 
        Brand.DOAnchorPosY(-297.2134f, 0.7f);
    }
}
