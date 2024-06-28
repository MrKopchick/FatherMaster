using System;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.PlayerLoop;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 dir;
    private float baseSpeed = 5; 
    private float currentSpeed; 
    private int lineToMove = 1;
    public float lineToDistance = 2.5f;
    private RunnerScore runnerScore;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text HP_Text;
    [SerializeField] private int health;
    [SerializeField] private RectTransform LosePanel;
    [SerializeField] private RectTransform ScoreText;
    [SerializeField] private RectTransform HighestScore;
    [SerializeField] private RectTransform NavigationsButtons;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip hurtSound;
    private AudioSource audioSource;
    public ParticleSystem CoinParticle;
    public ParticleSystem CucumberParticle;
    public ParticleSystem TomatoParticle;
    public RunnerScore score;
    
    void Start()
    {
        health = PlayerPrefs.GetInt("Health");
        baseSpeed = PlayerPrefs.GetFloat("Speed");
        audioSource = GetComponent<AudioSource>();    
        rb = GetComponent<Rigidbody>();
        runnerScore = FindObjectOfType<RunnerScore>(); 
        currentSpeed = baseSpeed;
        HP_Text.text = "HP: " + health.ToString() + " / " + PlayerPrefs.GetInt("MaxHP");
        UpdateScoreText(PlayerPrefs.GetInt("Score", 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            CoinParticle.Play();
            audioSource.clip = coinSound;
            audioSource.Play();
            Destroy(other.gameObject);
            int score = PlayerPrefs.GetInt("Score", 0);
            score++;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            UpdateScoreText(score);
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("block"))
        {
            Destroy(other.gameObject);
            health--;
            UpdateHealthText(health);
            Debug.Log(health);
            audioSource.clip = hurtSound;
            audioSource.Play();
            currentSpeed -= 2;
            if (health == 0)
            {
                StartCoroutine(Lose());
            }
        }
        
        if (other.collider.CompareTag("cucumbers"))
        {
            CucumberParticle.Play();
            Destroy(other.gameObject);
            if (health < PlayerPrefs.GetInt("MaxHP"))
            {
                health++;
            }
            UpdateHealthText(health);
            
            audioSource.clip = coinSound;
            audioSource.Play();
        }
        if (other.collider.CompareTag("tomato"))
        {
            TomatoParticle.Play();
            Destroy(other.gameObject);
            if (health < PlayerPrefs.GetInt("MaxHP"))
            {
                health++;
            }
            UpdateHealthText(health);
            
            audioSource.clip = coinSound;
            audioSource.Play();
        }
    }
    
    private IEnumerator Lose()
    {
        LosePanel.DOAnchorPosY(0, 0.3f);
        ScoreText.DOAnchorPosY( 150, 0.3f);
        HighestScore.DOAnchorPosY(-150, 0.3f);
        NavigationsButtons.DOAnchorPosY( 0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        score.SaveHighscore();
        SoundMicsher music = GameObject.FindObjectOfType<SoundMicsher>();
        music.Lose();
        Time.timeScale = 0;
    }
    
    private void UpdateScoreText(int score)
    {
        text.text = "Coins: " + score.ToString();
    }
    private void UpdateHealthText(int health)
    {
        HP_Text.text = "HP: " + health.ToString() + " / " + PlayerPrefs.GetInt("MaxHP");
    }
    

    void Update()
    {
        
        currentSpeed = baseSpeed + runnerScore.GetScore() / 40f;
        if (SwipeController.swipeRight) {
            if(lineToMove < 2) {
                lineToMove++;
            }
        }
        if(SwipeController.swipeLeft) {
            if (lineToMove > 0) {
                lineToMove--;   
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(lineToMove == 0) {
            targetPosition += Vector3.left * lineToDistance;
        }else if(lineToMove == 2) {
            targetPosition += Vector3.right * lineToDistance;
        }

        transform.position = targetPosition;
    }

    public List<Vector3> GetMovingPoints(float platformZ)
    {
        return new List<Vector3>()
        {
            new Vector3(-lineToDistance, 2, platformZ),
            new Vector3(lineToDistance, 2, platformZ)
        };
    }

    void FixedUpdate()
    {
        rb.velocity = currentSpeed * Vector3.forward;
    }
}
