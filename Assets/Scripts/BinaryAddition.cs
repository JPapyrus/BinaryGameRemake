using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BinaryAddition : MonoBehaviour
{
    public TextMeshProUGUI binaryDisplayOne;
    public TextMeshProUGUI binaryDisplayTwo;
    public TextMeshProUGUI scoreDisplay;
    public TMP_InputField textField;
    public int randomIntOne;
    public int randomIntTwo;
    public string binaryNum;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        randomIntOne = GenerateNumber();
        randomIntTwo = GenerateNumber();
        binaryDisplayOne.text = GenerateBinary(randomIntOne);
        binaryDisplayTwo.text = GenerateBinary(randomIntTwo);
        binaryNum = GenerateBinary(randomIntOne + randomIntTwo);
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

    void CheckAnswer(string answer)
    {
        if (answer == binaryNum)
        {
            score++;
            scoreDisplay.text = "Score: " + score;
            randomIntOne = GenerateNumber();
            randomIntTwo = GenerateNumber();
            binaryDisplayOne.text = GenerateBinary(randomIntOne);
            binaryDisplayTwo.text = GenerateBinary(randomIntTwo);
            binaryNum = GenerateBinary(randomIntOne + randomIntTwo);
        }

        else
        {
            CheckHighScore();
            SceneManager.LoadScene("GameOver");
        }
    }

    public void QuitPressed()
    {
        CheckHighScore();
        SceneManager.LoadScene("GameOver");
    }

    int GenerateNumber()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
            return Random.Range(0, 32);

        else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            return Random.Range(0, 64);

        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            return Random.Range(-64, 64);

        return 0;
    }

    string GenerateBinary(int convertThis)
    {
        sbyte randomSByte = System.Convert.ToSByte(convertThis);
        string tempBin = System.Convert.ToString(randomSByte, 2);
        string binString = "";

        switch (tempBin.Length)
        {
            case 1:
                binString = "0000 000" + tempBin;
                break;

            case 2:
                binString = "0000 00" + tempBin;
                break;

            case 3:
                binString = "0000 0" + tempBin;
                break;

            case 4:
                binString = "0000 " + tempBin;
                break;

            case 5:
                binString = "000" + tempBin.Substring(0,1) + " " + tempBin.Substring(1,4);
                break;

            case 6:
                binString = "00" + tempBin.Substring(0, 2) + " " + tempBin.Substring(2, 4);
                break;

            case 7:
                binString = "0" + tempBin.Substring(0, 3) + " " + tempBin.Substring(3, 4);
                break;

            case 8:
                binString = tempBin.Substring(0, 4) + " " + tempBin.Substring(4, 4);
                break;

            default:
                binString = tempBin.Substring(8, 4) + " " + tempBin.Substring(12, 4);
                break;
        }
        return binString;
    }

    void CheckHighScore()
    {
        PlayerPrefs.SetInt("Latest Score", score);
        switch (PlayerPrefs.GetString("Difficulty"))
        {
            case "Easy":
                if (PlayerPrefs.GetInt("EasyScoreBA") < score)
                    PlayerPrefs.SetInt("EasyScoreBA", score);
                break;

            case "Medium":
                if (PlayerPrefs.GetInt("MediumScoreBA") < score)
                    PlayerPrefs.SetInt("MediumScoreBA", score);
                break;

            case "Hard":
                if (PlayerPrefs.GetInt("HardScoreBA") < score)
                    PlayerPrefs.SetInt("HardScoreBA", score);
                break;
        }
    }
}
