using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotStream : MonoBehaviour
{
    public GameObject playerRootComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerRootComponent.GetComponent<Rigidbody>().AddForce(transform.forward * 70);
    }
}
