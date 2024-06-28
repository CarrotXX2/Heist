using UnityEngine;
using TMPro;
using UnityEngine;
using TMPro;
using System.Collections;

public class Type2 : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public string fullText2 = "Nadat je klaar bent ga naar de deur van je busje en klik E om te vertrekken";
    public float typingSpeed2 = 0.05f;

    private void Start()
    {
        textMeshPro.text = "";
        StartCoroutine(DelayedTypeText());
    }

    private IEnumerator DelayedTypeText()
    {
        // Wait for 6 seconds before starting to type the text
        yield return new WaitForSeconds(12f);
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText2.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed2);
        }
        yield return new WaitForSeconds(3);
        textMeshPro.text = "";
    }
}