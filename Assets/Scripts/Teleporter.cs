using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject teleporterEnd;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.position = teleporterEnd.transform.position;
    }
}