using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform PausePanel;
    [SerializeField] private TMP_Text Random_Text;
    [SerializeField] private AudioClip ButtonSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
        Time.timeScale = 1;
    }
    
    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
