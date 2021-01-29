using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;

    void FixedUpdate() {
        Run();
    }

    private void Run() {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalAxis, 0, verticalAxis) * (moveSpeed * Time.deltaTime));
    }
}
