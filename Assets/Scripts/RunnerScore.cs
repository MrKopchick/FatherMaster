using UnityEngine;
using TMPro;

public class RunnerScore : MonoBehaviour
{
    public TMP_Text[] scoreText; 
    public TMP_Text RecordText;
    private float score = 0f;

    void Start()
    {
        RecordText.text = "HIGHEST SCORE: " + (int)PlayerPrefs.GetFloat("HighScore");
    }
    public float GetScore()
    { 
        return score;
    }
    
    void Update()
    {
        score += Time.deltaTime * 10f;
        if (scoreText != null)
        {
            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].text = "Score: " + Mathf.Round(score).ToString();
            }
        }
    }
    
    public void SaveHighscore()
    {
        if ( score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
            Debug.Log("High Record Complete " + PlayerPrefs.GetFloat("HighScore"));
            RecordText.text = "HIGHEST SCORE: " + (int)PlayerPrefs.GetFloat("HighScore");
        }
    }

    
}