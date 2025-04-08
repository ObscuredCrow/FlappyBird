using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 _startPosition;

    public void FixedUpdate() {
        ResetPosition();
        Move();
    }

    private void ResetPosition() {
        if (GameController.Instance.State != GameState.Start) return;

        transform.localPosition = _startPosition;
    }

    private void Move() {
        if (GameController.Instance.State != GameState.Run) return;

        var destination = new Vector3(-18, transform.localPosition.y, 0);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, 1f * Time.deltaTime);
    }

    private void Awake() => _startPosition = transform.localPosition;
}
