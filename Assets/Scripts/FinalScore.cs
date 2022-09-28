using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    private ScoreKeepre _scoreAmount;

    private void Awake()
    {
        _scoreAmount = FindObjectOfType<ScoreKeepre>();
    }
    void Start()
    {   
        _scoreText.text = _scoreAmount.GetCurrentScore().ToString();
    }

}
