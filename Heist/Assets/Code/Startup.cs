using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public float fadeDuration = 5.0f; 
    public Image image; 

    private Color originalColor;

    void Start()
    {
        if (image == null)
        {
            return;
        }

        originalColor = image.color;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}