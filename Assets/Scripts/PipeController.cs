using UnityEngine;

public class PipeController : MonoBehaviour
{
    public void RandomizePosition() {
        var height = Random.Range(GameController.Instance.MinPipeHeight, GameController.Instance.MaxPipeHeight);
        var position = transform.localPosition;
        position.y = height;
        transform.localPosition = position;
    }

    private void Start() => RandomizePosition();
}
