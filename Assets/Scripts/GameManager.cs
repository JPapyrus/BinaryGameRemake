using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string gamemode = "";

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveGameMode(string gm)
    {
        gamemode = gm;
    }

    public void LoadGame()
	{
		SceneManager.LoadScene(gamemode);
	}

    public void SaveDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
    }
}
