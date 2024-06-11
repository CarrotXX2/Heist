using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Dageindig : MonoBehaviour
{
    public TMP_Text text; // Sleep hier je Text component naartoe in de Inspector
    public float timeRemaining = 7 * 60; // 7 minuten in seconden
    private bool timerIsRunning = false;

    void Start()
    {
        // Start de timer
        timerIsRunning = true;
        StartCoroutine(CountdownTimer());
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Update de timer
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                // Timer is afgelopen
                timeRemaining = 0;
                timerIsRunning = false;
                SwitchScene();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Zorg ervoor dat de tijd niet negatief is
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // Delen door 60 om minuten en seconden te krijgen
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Update de Text component
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Dag");
    }
}