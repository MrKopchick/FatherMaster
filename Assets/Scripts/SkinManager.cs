using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins;
    public Button nextButton;
    public Button prevButton;
    private int currentIndex = 0;
    public static int selectedSkinIndex;
    [SerializeField] private AudioClip ButtonSound;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        UpdateSkinDisplay();
        nextButton.onClick.AddListener(NextSkin);
        prevButton.onClick.AddListener(PrevSkin);
    }

    void NextSkin()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play();
        skins[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % skins.Length;
        skins[currentIndex].SetActive(true);
        SelectSkin();
    }

    void PrevSkin()
    {
        audioSource.clip = ButtonSound;
        audioSource.Play(); 
        skins[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + skins.Length) % skins.Length;
        skins[currentIndex].SetActive(true);
        SelectSkin();
    }

    void SelectSkin()
    {
        selectedSkinIndex = currentIndex;
        Debug.Log("Selected Skin Index: " + selectedSkinIndex);
    }

    void UpdateSkinDisplay()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(i == currentIndex);
        }
    }
    
}
