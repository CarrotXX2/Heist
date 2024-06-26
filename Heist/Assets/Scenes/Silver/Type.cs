using UnityEngine;
using TMPro;
using System.Collections;

public class Type : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public string fullText = "Even snel overval plegen wat dingentjes stelen en dan naar huis!";
    public float typingSpeed = 0.05f; 

    private void Start()
    {
        textMeshPro.text = ""; 
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(3);
        textMeshPro.text = "";
    }
}