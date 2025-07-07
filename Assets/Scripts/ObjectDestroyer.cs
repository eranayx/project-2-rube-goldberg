using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject platformToDestroy;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(platformToDestroy);
    }
}
