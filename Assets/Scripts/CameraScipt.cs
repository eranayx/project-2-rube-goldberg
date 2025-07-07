using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScipt : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;
    [SerializeField]
    private DominoTrigger angle1Trigger;
    [SerializeField]
    private PlinkoTrigger angle2Trigger;
    [SerializeField]
    private GameObject newAngle1;
    [SerializeField]
    private GameObject newAngle2;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float followDistance = 5f;

    private bool followingBall = true;

    private void Start()
    {
        angle1Trigger = GameObject.FindGameObjectWithTag("Domino Trigger").GetComponent<DominoTrigger>();
        angle2Trigger = GameObject.FindGameObjectWithTag("Plinko Trigger").GetComponent<PlinkoTrigger>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (angle1Trigger.triggered)
        {
            EaseToward(newAngle1, ref angle1Trigger.triggered);
        }

        else if (angle2Trigger.triggered)
        {
            EaseToward(newAngle2, ref angle2Trigger.triggered);
        }

        else if (followingBall)
        {
            // Follow the ball
            Vector3 objPosition = objectToFollow.transform.position;
            transform.position = new Vector3(objPosition.x, objPosition.y, objPosition.z + followDistance);
        }
    }

    private void EaseToward(GameObject newAngle, ref bool trigger)
    {
        var moveStep = moveSpeed * Time.deltaTime;
        var rotateStep = rotateSpeed * Time.deltaTime;
        Vector3 velocity = Vector3.zero;

        followingBall = false;

        // Move / rotate towards last (fixed) camera angle
        transform.position = Vector3.SmoothDamp(transform.position, newAngle.transform.position, ref velocity, moveStep);
        transform.rotation = Quaternion.Lerp(transform.rotation, newAngle.transform.rotation, rotateStep);

        // Snap location when near end location
        if (Vector3.Distance(transform.position, newAngle.transform.position) < moveStep && transform.rotation == newAngle.transform.rotation)
        {
            transform.position = newAngle.transform.position;
            trigger = false;
        }
    }
}
