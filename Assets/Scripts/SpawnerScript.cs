// Should combine with track spawner script for general spawner

using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private int amount;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private PlinkoTrigger plinkoTrigger;

    private bool doneSpawning;

    private void Start()
    {
        plinkoTrigger = GameObject.FindGameObjectWithTag("Plinko Trigger").GetComponent<PlinkoTrigger>();
    }

    private void Update()
    {
        if (plinkoTrigger.triggered && !doneSpawning)
        {
            Vector3 parent = gameObject.GetComponent<Transform>().position;
            ball.SetActive(true);

            for (int i = 0; i < amount; i++)
            {
                Instantiate(ball, new Vector3(parent.x, parent.y - 1, parent.z + Random.Range(-2.2f, 3.7f)), Quaternion.identity);
            }

            doneSpawning = true;
        }
    }
}
