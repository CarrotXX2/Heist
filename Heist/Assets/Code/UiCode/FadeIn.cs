using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Voeg deze regel toe

public class FadeInImage : MonoBehaviour
{
    public Image image; // Sleep hier je Image component naartoe in de Inspector
    public float fadeDuration = 3.0f; // De duur van de fade-in in seconden
    public float waitAfterFade = 3.0f; // De tijd om te wachten na de fade-in

    void Death()
    {
        // Start de coroutine om de afbeelding in te laten faden en vervolgens de scène te laden
        StartCoroutine(FadeInAndLoadScene());
    }

    IEnumerator FadeInAndLoadScene()
    {
        yield return StartCoroutine(FadeIn());

        // Wacht voor een specifieke tijd na de fade-in
        yield return new WaitForSeconds(waitAfterFade);

        // Laad de nieuwe scène
        SceneManager.LoadScene("BuyMenu 1");
    }

    IEnumerator FadeIn()
    {
        // Zorg ervoor dat de afbeelding helemaal transparant begint
        Color color = image.color;
        color.a = 0;
        image.color = color;

        // Verhoog de alfa waarde geleidelijk over de duur
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / fadeDuration);
            image.color = color;
            yield return null;
        }

        // Zorg ervoor dat de afbeelding volledig zichtbaar is aan het einde van de fade-in
        color.a = 1;
        image.color = color;
    }
}