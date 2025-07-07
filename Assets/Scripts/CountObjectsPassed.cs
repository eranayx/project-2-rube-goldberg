using UnityEngine;

public class CountObjectsPassed : MonoBehaviour
{
    [SerializeField]
    private int numberOfObjects;

    private static int objectsPassed;

    public bool allObjectsPassed = false;

    private void OnTriggerEnter(Collider other)
    {
        objectsPassed++;

        if (objectsPassed == numberOfObjects)
        {
            allObjectsPassed = true;
        }
    }
}
