using UnityEngine;

public class PlinkoTrigger : MonoBehaviour
{
    public bool triggered;

    private bool spawnedOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        // Ensure balls only spawn once even if multiple collisions
        // Not sure if necessary
        if (!spawnedOnce)
        {
            triggered = true;
            spawnedOnce = true;
        }
    }
}