using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // destinations, targets
    public Transform[] targets;

    // speed
    public float speed = 1;

    // flag that sets weather we are moving or not
    bool isMoving = false;

    // next destination index
    int nextIndex;

    // Start is called before the first frame update
    void Start()
    {
        // set the player to the first target
        transform.position = targets[0].position;

        // next destination is 1;
        nextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // check for input
        HandleInput();

        // move the platform
        HandleMovement();
    }

    void HandleInput()
    {
        // check for Fire1 axis
        if (Input.GetButtonDown("Fire1"))
        {
            // negate isMoving
            isMoving = !isMoving;
        }
    }

    // take care of movement
    void HandleMovement()
    {
        // if we are not moving exit
        if (!isMoving) return;

        //calculate the distance form target
        float distance = Vector3.Distance(transform.position, targets[nextIndex].position);

        //have we arrived?
        if (distance > 0)
        {

            // calcuate how much we need to move (step) d = v * t
            float step = speed * Time.deltaTime;

            //move by that step
            transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
        }
        // if we have arrived we should update nextIndex
        else
        {
            // next index increased by one
            nextIndex++;

            // array element index starst at 0 and goes all the wat to length-1
            if (nextIndex == targets.Length)
            {
                nextIndex = 0;
            }

            // stop moving 
            isMoving = false;
        }
    }
}
