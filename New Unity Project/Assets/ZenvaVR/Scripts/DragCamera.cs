using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenvaVR
{
    public class DragCamera : MonoBehaviour
    {
#if UNITY_EDITOR
        // flag to keep track wheather we are draging or not 
        bool isDragging = false;

        // starting point of a camera movement 
        float startMouseX;
        float startMouseY;

        // camera component 
        Camera cam;

        // Start is called before the first frame update
        void Start()
        {
            // get our camera component
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            // if we press the left button and we haven't started dragging 
            if (Input.GetMouseButtonDown(1) && !isDragging)
            {
                // set the flag to true
                isDragging = true;

                // save the mouse to starting position 
                startMouseX = Input.mousePosition.x;
                startMouseY = Input.mousePosition.y;

            }
            // if we are not pressing the left button, and we have started dragging 
            else if (Input.GetMouseButtonUp(1) && isDragging)
            {
                // set the flag to false 
                isDragging = false;
            }
        }

        void LateUpdate()
        {
            // check if we are dragging 
            if (isDragging)
            {
                // Calculate current mouse position
                float endMouseX = Input.mousePosition.x;
                float endMouseY = Input.mousePosition.y;

                // Difference (in screen coordinates)
                float diffX = endMouseX - startMouseX;
                float diffY = endMouseY - startMouseY;

                // New center of a screen
                float newCenterX = Screen.width / 2 + diffX;
                float newCenterY = Screen.height / 2 + diffY;

                // get the world coordinate, this is where we should be looking at
                Vector3 LookHerePoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));

                // make our camera look at the 'LookHerePoint'
                transform.LookAt(LookHerePoint);

                // starting position for the next call 
                startMouseX = endMouseX;
                startMouseY = endMouseY;
            }
        }
#endif
    }
}
