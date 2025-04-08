using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Settings")]
    public float MinPipeHeight = -3.12f;
    public float MaxPipeHeight = 2.52f;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip _pointClip;

    [HideInInspector] public GameState State = GameState.Start;

    private int _score = 0;
    private int _highScore = 0;
    private AudioSource _audio;

    private void Update() {
        StartGame();
        ResetGame();
    }

    public void StartGame() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && State == GameState.Start) {
            State = GameState.Run;
            _score = 0;
            AddToScore(0);
            foreach (var pipe in FindObjectsByType<PipeController>(FindObjectsSortMode.None))
                pipe.RandomizePosition();
        }
    }

    public void AddToScore(int amount) {
        if (State != GameState.Run) return;

        _audio.PlayOneShot(_pointClip);
        _score += amount;
        UIController.Instance.SetScore(_score);
    }

    public void SetHighScore() {
        if (State != GameState.Stop) return;

        _highScore = _score > _highScore ? _score : _highScore;
        UIController.Instance.SetHighScore(_highScore);
    }

    public void StopGame() { 
        State = GameState.Stop;
        SetHighScore();
    }

    public void ResetGame() {
        if (Input.GetKeyDown(KeyCode.R) && State == GameState.Stop)
            State = GameState.Start; 
    }

    private void Awake() { 
        Instance ??= this;
        _audio = GetComponent<AudioSource>();
        _highScore = PlayerPrefs.GetInt("highscore", 0);
    }
}