using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score: " + PlayerPrefs.GetInt("Latest Score");
    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
