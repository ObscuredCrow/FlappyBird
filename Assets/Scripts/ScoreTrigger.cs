using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D trigger) {
        if (trigger.tag != "Player") return;

        GameController.Instance.AddToScore(1);
    }
}
