using UnityEngine;

public class RepositionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag != "Pipe" && collider.tag != "Ground") return;

        var position = Vector3.zero;
        switch (collider.tag) {
            case "Pipe":
                var parent = collider.transform.parent;
                position = parent.localPosition;
                position.x = 0;
                parent.localPosition = position;
                parent.GetComponent<PipeController>().RandomizePosition();
                break;

            case "Ground":
                position = collider.transform.localPosition;
                position.x = 0;
                collider.transform.localPosition = position;
                break;
        }
    }
}
