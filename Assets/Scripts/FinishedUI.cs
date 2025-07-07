using UnityEngine;

public class FinishedUI : MonoBehaviour
{
    [SerializeField]
    private CountObjectsPassed countObjectsPassed;
    [SerializeField]
    private GameObject finishedUI;

    private void Start()
    {
        countObjectsPassed = GameObject.FindGameObjectWithTag("Finished UI Trigger").GetComponent<CountObjectsPassed>();
    }

    private void Update()
    {
        if (countObjectsPassed.allObjectsPassed)
        {
            finishedUI.SetActive(true);
        }
    }
}
