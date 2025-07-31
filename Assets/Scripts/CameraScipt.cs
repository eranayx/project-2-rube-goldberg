using UnityEngine;

public class CameraScipt : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;

    // What if I wanted to add more triggers and angles?
    // Should I be defining a struct/class MyClass with trigger and newAngle variables
    // Then use a array with instances of MyClass to store and iterate thru them?
    // If so, how can I add a large amount of values in the inspector?

    // DominoTrigger, PlinkoTrigger, CountObjectsPassed are all classes
    // with a variable that turn true after a certain condition
    [SerializeField]
    private DominoTrigger angle1Trigger;
    [SerializeField]
    private PlinkoTrigger angle2Trigger;
    [SerializeField]
    private CountObjectsPassed angle3Trigger;
    [SerializeField]
    private GameObject newAngle1;
    [SerializeField]
    private GameObject newAngle2;
    [SerializeField]
    private GameObject newAngle3;   

    // I feel these speeds aren't changing how fast it's moving/rotating when its too little
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    // How far behind the ball the camera follows
    [SerializeField]
    private float followDistance = 5f;

    private bool followingBall = true;

    // Is there a better way than a dummy variable
    private bool defaultBoolRef = true;

    private void Start()
    {
        angle1Trigger = GameObject.FindGameObjectWithTag("Domino Trigger").GetComponent<DominoTrigger>();
        angle2Trigger = GameObject.FindGameObjectWithTag("Plinko Trigger").GetComponent<PlinkoTrigger>();
        angle3Trigger = GameObject.FindGameObjectWithTag("Finished UI Trigger").GetComponent<CountObjectsPassed>();
    }

    private void FixedUpdate()
    {
        if (angle1Trigger.triggered)
        {
            EaseToward(newAngle1, ref angle1Trigger.triggered);
        }

        else if (angle2Trigger.triggered)
        {
            EaseToward(newAngle2, ref angle2Trigger.triggered);
        }

        else if (angle3Trigger.allObjectsPassed)
        {
            EaseToward(newAngle3);
        }

        else if (followingBall)
        {
            // Follow the ball
            Vector3 objPosition = objectToFollow.transform.position;
            transform.position = new Vector3(objPosition.x, objPosition.y, objPosition.z + followDistance);
        }
    }

    // Is there a better way than a dummy variable to overload the function if I needed to
    private void EaseToward(GameObject newAngle)
    {
        EaseToward(newAngle, ref defaultBoolRef);
    }

    // Eases camera toward new position
    private void EaseToward(GameObject newAngle, ref bool trigger)
    {
        float moveStep = moveSpeed * Time.fixedDeltaTime;
        float rotateStep = rotateSpeed * Time.fixedDeltaTime;
        Vector3 velocity = Vector3.zero;

        followingBall = false;

        // Move / rotate towards last (fixed) camera angle
        transform.position = Vector3.SmoothDamp(transform.position, newAngle.transform.position, ref velocity, moveStep);

        // How can I not make it rotate so awkwardly
        transform.rotation = Quaternion.Lerp(transform.rotation, newAngle.transform.rotation, rotateStep);

        // Snap location when near end location
        if (Vector3.Distance(transform.position, newAngle.transform.position) < moveStep && transform.rotation == newAngle.transform.rotation)
        {
            transform.position = newAngle.transform.position;
            trigger = false;
        }
    }
}
