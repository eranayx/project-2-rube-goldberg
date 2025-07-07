using UnityEngine;

public class DominoTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject platformToDestroy;

    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Stop ball
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // Allow dominos to fall
            gameObject.GetComponent<BoxCollider>().isTrigger = false;

            // Drops ball
            Destroy(platformToDestroy);

            // Switch camera angle
            triggered = true;
        }
    }
}
