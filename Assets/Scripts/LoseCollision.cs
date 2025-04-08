using UnityEngine;

public class LoseCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag != "Player") return;

        collision.gameObject.GetComponent<BirdController>().Hit();
        GameController.Instance.StopGame();
    }
}
