using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RagdollToggle : MonoBehaviour {
    
    private BoxCollider BoxCollider;
    private Rigidbody RigidBody;

    private SphereCollider HeadCollider;
    private CapsuleCollider[] ChildrenCollider;
    private Rigidbody[] ChildrenRigidbody;
    
    void Awake() {
        BoxCollider = GetComponent<BoxCollider>();
        RigidBody = GetComponent<Rigidbody>();

        HeadCollider = GetComponentInChildren<SphereCollider>();
        ChildrenCollider = GetComponentsInChildren<CapsuleCollider>();
        ChildrenRigidbody = GetComponentsInChildren<Rigidbody>();
    }

    private void Start() {
        RagdollActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R Key Pressed");
            RagdollActive(true);
        }
    }

    public void RagdollActive(bool active) {
        //children
        HeadCollider.enabled = active;
        foreach (var collider in ChildrenCollider) {
            collider.enabled = active;
        }
        foreach (var rigidbody in ChildrenRigidbody)
        {
            rigidbody.detectCollisions = active;
            rigidbody.isKinematic = !active;
            rigidbody.AddForce(Random.Range(20, 50),Random.Range(150, 250),Random.Range(20, 50));
        }
        
        // root
        RigidBody.detectCollisions = !active;
        RigidBody.isKinematic = !active;
        BoxCollider.enabled = !active;
    }

}
