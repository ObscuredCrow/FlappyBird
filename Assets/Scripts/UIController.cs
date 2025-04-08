using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _reset;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _highScore;

    private void SetVisibility() {
        _start.SetActive(GameController.Instance.State == GameState.Start);
        _score.gameObject.SetActive(GameController.Instance.State != GameState.Start);
        _highScore.gameObject.SetActive(GameController.Instance.State != GameState.Start);
        _gameOver.SetActive(GameController.Instance.State == GameState.Stop);
        _reset.SetActive(GameController.Instance.State == GameState.Stop);
    }

    public void SetHighScore(int score) { 
        _highScore.text = $"High Score: {score}";
        PlayerPrefs.SetInt("highscore", score);
    }

    public void SetScore(int score) => _score.text = score.ToString();

    private void Awake() { 
        Instance ??= this;
        SetHighScore(PlayerPrefs.GetInt("highscore", 0));
    }

    private void Update() => SetVisibility();
}