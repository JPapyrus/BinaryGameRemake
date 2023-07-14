using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBinary : MonoBehaviour
{
    public int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Difficulty") == "Easy")
            randomInt = Random.Range(0, 64);

        else if(PlayerPrefs.GetString("Difficulty") == "Medium")
            randomInt = Random.Range(0, 128);

        else if(PlayerPrefs.GetString("Difficulty") == "Hard")
            randomInt = Random.Range(-128, 128);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
