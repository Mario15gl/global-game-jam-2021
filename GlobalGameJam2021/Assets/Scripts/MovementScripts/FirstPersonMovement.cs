using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public Transform cam;
    public float moveScaleFactor = 8.0f;

    void HandleInput()
    {

        
        float FrontBack = Input.GetAxisRaw("FrontBackForce");
        float LeftRight = Input.GetAxisRaw("LeftRightForce");
        Vector3 direction = new Vector3(LeftRight, 0, FrontBack);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;


            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            GetComponent<CharacterController>().Move(moveDirection/moveScaleFactor);
        }

        if (Input.GetAxisRaw("JumpPlayer") > 0)
        {
            GetComponent<CharacterController>().Move(Vector3.up/ moveScaleFactor);
        }
        if (Input.GetAxisRaw("JumpPlayer") < 0)
        {
            GetComponent<CharacterController>().Move(Vector3.down / moveScaleFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
