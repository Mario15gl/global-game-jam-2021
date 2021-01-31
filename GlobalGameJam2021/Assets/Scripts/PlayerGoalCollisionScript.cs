using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGoalCollisionScript : MonoBehaviour
{
    public UnityEvent OnPlayerCollision;

    public GameObject PlayerObject;

    // Start is called before the first frame update
    void Start()
    {
        // ...
    }

    // Goal Update Function
    void Update()
    {
        // ...
    }

    // Check to see if the level goal has collided with the
    // player and set the collision boolean accordingly
    private void OnTriggerEnter(Collider other)
    {
        // Check that the other collider is the player
        if ( other.name == PlayerObject.name) // If the other object has a particular player component...
        {
            OnPlayerCollision?.Invoke();
        }
    }
}