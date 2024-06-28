using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    public Image panelImage;
    public Color startColor = Color.cyan;
    public Color endColor = Color.green;
    public float duration = 3.0f;

    private float lerpTime = 0.0f;
    private bool isReversing = false;

    void Update()
    {
        if (isReversing)
        {
            lerpTime -= Time.deltaTime / duration;
        }
        else
        {
            lerpTime += Time.deltaTime / duration;
        }
        
        panelImage.color = Color.Lerp(startColor, endColor, lerpTime);
        
        if (lerpTime >= 1.0f)
        {
            isReversing = true;
        }
        else if (lerpTime <= 0.0f)
        {
            isReversing = false;
        }
    }
}