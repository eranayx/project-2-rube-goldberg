using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject teleporterEnd;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleporterEnd.transform.position;
        // Should not be inside a teleporter script
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}