using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeepre : MonoBehaviour
{

    static ScoreKeepre instance;
    private int _score = 0;


    private void Awake()
    {
        ManageSingleton();
    }
    public int GetCurrentScore()
    {
        return _score;
    }

    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    
}
