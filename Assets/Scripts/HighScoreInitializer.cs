using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreInitializer : MonoBehaviour
{
    public TextMeshProUGUI[] highScores = new TextMeshProUGUI[9];

    void Start()
    {
        if(!PlayerPrefs.HasKey("HasHighScores"))
        {
            PlayerPrefs.SetInt("HasHighScores", 1);
            PlayerPrefs.SetInt("EasyScoreBtN", 0);
            PlayerPrefs.SetInt("MediumScoreBtN", 0);
            PlayerPrefs.SetInt("HardScoreBtN", 0);
            PlayerPrefs.SetInt("EasyScoreNtB", 0);
            PlayerPrefs.SetInt("MediumScoreNtB", 0);
            PlayerPrefs.SetInt("HardScoreNtB", 0);
            PlayerPrefs.SetInt("EasyScoreBA", 0);
            PlayerPrefs.SetInt("MediumScoreBA", 0);
            PlayerPrefs.SetInt("HardScoreBA", 0);
        }

        highScores[0].SetText(PlayerPrefs.GetInt("EasyScoreBtN").ToString());
        highScores[1].SetText(PlayerPrefs.GetInt("MediumScoreBtN").ToString());
        highScores[2].SetText(PlayerPrefs.GetInt("HardScoreBtN").ToString());
        highScores[3].SetText(PlayerPrefs.GetInt("EasyScoreNtB").ToString());
        highScores[4].SetText(PlayerPrefs.GetInt("MediumScoreNtB").ToString());
        highScores[5].SetText(PlayerPrefs.GetInt("HardScoreNtB").ToString());
        highScores[6].SetText(PlayerPrefs.GetInt("EasyScoreBA").ToString());
        highScores[7].SetText(PlayerPrefs.GetInt("MediumScoreBA").ToString());
        highScores[8].SetText(PlayerPrefs.GetInt("HardScoreBA").ToString());
    }
}
