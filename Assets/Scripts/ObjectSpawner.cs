// Should combine with plinko ball spawner script for general spawner
// Or use setActive instead of instantiate

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        objectToSpawn.SetActive(true);

        // Should not be in a spawner script
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
