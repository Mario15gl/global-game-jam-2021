using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;

    public bool isEnabled = true;
    public float speed = 6;
    public float jumpValue = 100;

    bool isJump = false;
    
    void HandleInput()
    {
        //axis controls for front and back movement + left right
        float FrontBack = Input.GetAxisRaw("FrontBackForce");
        float LeftRight = Input.GetAxisRaw("LeftRightForce");
        //direction with combination of frontback and leftright movement
        Vector3 direction = new Vector3(LeftRight, 0, FrontBack);
        Vector3 forcePosition = new Vector3(0.0f, -0.5f, 0.0f);

        //if direction is larger than deadzone
        if (direction.magnitude >= 0.1f)
        {
            //find target angle for movement using direction vector and camera direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //get final move direction using target angle and forward vector
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //add force to player along movedirection with defined speed
            GetComponent<Rigidbody>().AddForceAtPosition(moveDirection * speed, transform.position );
        }

        //if jump is pressed
        if(Input.GetAxisRaw("JumpPlayer") > 0 )
        {
            //if player isn't already jumpping
            if (isJump == false )
            {
                //add jump force and set player to jumpping
                GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * jumpValue, transform.position);
                isJump = true;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the user should be able to move the sock
        if (isEnabled) // If the sock should move...
        {
            HandleInput(); // Handle player input
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space) == false && other.gameObject.tag != ("Player") && isJump == true)
        {
            isJump = false;
        }
    }
    


}
