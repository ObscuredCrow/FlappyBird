using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _jumpAmount = 30;

    [Header("Sounds")]
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private AudioClip _clickClip;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private AudioSource _audio;

    public void Hit() => _audio.PlayOneShot(_hitClip);

    private void Update() {
        ResetPosition();
        Jump();
    }

    private void ResetPosition() {
        if (GameController.Instance.State != GameState.Start)  return;

        transform.localPosition = _startPosition;
        _rigidbody.totalForce = Vector2.zero;
    }

    private void Jump() {
        _rigidbody.simulated = GameController.Instance.State == GameState.Run;
        if (GameController.Instance.State != GameState.Run) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            _audio.PlayOneShot(_clickClip);
            _rigidbody.AddForce(Vector3.up * _jumpAmount);
        }
    }

    private void Awake() { 
        _rigidbody = GetComponent<Rigidbody2D>(); 
        _audio = GetComponent<AudioSource>();
    }
}