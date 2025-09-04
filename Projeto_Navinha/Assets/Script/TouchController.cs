using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Vector3 initialScale;
    private Quaternion initialRotation;

    private Vector3 touchOffset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 5f));

            if(Input.touchCount == 1)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    touchOffset = transform.position - touchPosition;
                }
                else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    transform.position = touchPosition + touchOffset; 
                }
            }

            if(Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
                float currentMagnitude = (touch1.position - touch2.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                transform.localScale += Vector3.one * difference * 0.01f;

                Vector2 prevDir = (touch2PrevPos - touch1PrevPos).normalized;
                Vector2 currentDir = (touch2.position - touch1.position).normalized;
                float angle = Vector2.SignedAngle(prevDir, currentDir);

                transform.Rotate(Vector3.forward, angle);

            }
        }
        else
        {

            if(transform.localScale != initialScale || transform.rotation != initialRotation)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime * 2f);
                transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * 2f);
            }
        }
    }
}
