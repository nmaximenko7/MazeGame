using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter
{
    private static ScoreCounter _instance;
    public int Score { get; set; }

    public static ScoreCounter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreCounter();
                Debug.Log("Instanse score counter");
            }
            return _instance;
        }
    }
}
