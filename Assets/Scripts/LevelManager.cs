using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _timeToLoad = 1.5f;
    private ScoreKeepre _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeepre>();
    }
    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadEndScreen()
    {
        StartCoroutine(DelayLoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(_timeToLoad);
        SceneManager.LoadScene(2);
    }
}
