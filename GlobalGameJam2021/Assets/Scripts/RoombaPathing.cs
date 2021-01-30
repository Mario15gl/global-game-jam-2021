using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoombaPathing : MonoBehaviour {
    [SerializeField] private List<Transform> WaypointsList;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private int waypointIndex = 0;

    void Start() {
        transform.position = WaypointsList[waypointIndex].transform.position;
        transform.rotation = WaypointsList[waypointIndex].transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(RotateThenMoveTowardsNextWaypoint());
    }
    
    private IEnumerator RotateThenMoveTowardsNextWaypoint() {
        // determine which position/waypoint to move towards
        var targetPosition = WaypointsList[waypointIndex].transform.position;
        // determine which direction to rotate towards
        var targetDirection = targetPosition - transform.position;
        
        // the movement size is equal to the speed times delta time
        var movementThisFrame = moveSpeed * Time.deltaTime;
        var rotationThisFrame = rotateSpeed * Time.deltaTime * 3;
        
        // rotate the forward vector towards the target direction by one step
        Vector3 newDirection =
            Vector3.RotateTowards(transform.forward, targetDirection, rotationThisFrame, 0.0f);

        if (waypointIndex <= WaypointsList.Count - 1) {
            // move towards the next waypoint
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);
            
            // calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForSeconds(2);
            if ((waypointIndex != WaypointsList.Count - 1) && (transform.position == targetPosition)) {
                waypointIndex++;
            }
        }
    } 

    [ContextMenu("Autofill Waypoints")]
    void AutoFillWaypoints() {
        WaypointsList = FindObjectsOfType<Transform>()
            .Where(t => t.name.ToLower().Contains("Waypoint"))
            .ToList();
    }
}