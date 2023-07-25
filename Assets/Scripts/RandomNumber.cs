using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomNumber : MonoBehaviour
{
    public TextMeshProUGUI numberDisplay;
    public TextMeshProUGUI scoreDisplay;
    public TMP_InputField textField;
    public int randomInt;
    public string binaryNum;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNumber();
        GenerateBinary();
    }

    void GenerateNumber()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
            randomInt = Random.Range(0, 64);

        else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            randomInt = Random.Range(0, 128);

        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            randomInt = Random.Range(-128, 128);

        numberDisplay.text = randomInt.ToString();
    }
    
    void GenerateBinary()
    {
        sbyte randomSByte = System.Convert.ToSByte(randomInt);
        string binString = System.Convert.ToString(randomSByte, 2);

        switch (binString.Length)
        {
            case 1:
                binaryNum = "0000 000" + binString;
                break;

            case 2:
                binaryNum = "0000 00" + binString;
                break;

            case 3:
                binaryNum = "0000 0" + binString;
                break;

            case 4:
                binaryNum = "0000 " + binString;
                break;

            case 5:
                binaryNum = "000" + binString.Substring(0, 1) + " " + binString.Substring(1, 4);
                break;

            case 6:
                binaryNum = "00" + binString.Substring(0, 2) + " " + binString.Substring(2, 4);
                break;

            case 7:
                binaryNum = "0" + binString.Substring(0, 3) + " " + binString.Substring(3, 4);
                break;

            case 8:
                binaryNum = binString.Substring(0, 4) + " " + binString.Substring(4, 4);
                break;

            default:
                binaryNum = binString.Substring(8, 4) + " " + binString.Substring(12, 4);
                break;
        }
    }

    void CheckHighScore()
    {
        PlayerPrefs.SetInt("Latest Score", score);
        switch (PlayerPrefs.GetString("Difficulty"))
        {
            case "Easy":
                if (PlayerPrefs.GetInt("EasyScoreNtB") < score)
                    PlayerPrefs.SetInt("EasyScoreNtB", score);
                break;

            case "Medium":
                if (PlayerPrefs.GetInt("MediumScoreNtB") < score)
                    PlayerPrefs.SetInt("MediumScoreNtB", score);
                break;

            case "Hard":
                if (PlayerPrefs.GetInt("HardScoreNtB") < score)
                    PlayerPrefs.SetInt("HardScoreNtB", score);
                break;
        }
    }

    void CheckAnswer(string answer)
    {
        if (answer == binaryNum)
        {
            score++;
            scoreDisplay.text = "Score: " + score;
            GenerateNumber();
            GenerateBinary();
        }

        else
        {
            CheckHighScore();
            SceneManager.LoadScene("GameOver");
        }
    }

    public void EnterPressed()
    {
        string answer = textField.text;
        if (answer.Length == 0)
        { } // Do nothing. AKA Wait for the player to actually put something inside the textbox

        else
        {
            if (answer.Length == 8)
                answer = textField.text.Substring(0, 4) + " " + textField.text.Substring(4, 4);

            textField.text = "";
            CheckAnswer(answer);
        }
    }

    public void QuitPressed()
    {
        CheckHighScore();
        SceneManager.LoadScene("GameOver");
    }
}
