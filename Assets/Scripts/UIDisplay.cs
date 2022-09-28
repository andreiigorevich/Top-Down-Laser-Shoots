using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] float _sliderSpeed = 30f;
    private Health _health;
    private ScoreKeepre _score;

    private void Awake()
    {
        _score = FindObjectOfType<ScoreKeepre>();
        _health = FindObjectOfType<Player>().GetComponent<Health>();
        _healthBar.maxValue = _health.GetCurrentHealth();
    }

    private void Update()
    {
        _scoreText.text = _score.GetCurrentScore().ToString("000000");
        _healthBar.value = Mathf.Lerp(_healthBar.value, _health.GetCurrentHealth(), Time.deltaTime * _sliderSpeed);
    }
}
