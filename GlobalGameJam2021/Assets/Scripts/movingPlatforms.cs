using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms : MonoBehaviour
{
    public Vector3[] positions;
    public float speed;
    public float timeToWait; //seconds
    private int currentPosition = 0;
    private bool isIdle = false;
    public float positionPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stop());
    }

    void Update()
    {
        if (isIdle == false)
        {
            if (currentPosition + 1 == positions.Length)
            {
                transform.position = Vector3.Lerp(transform.position, positions[0], speed * Time.deltaTime);
                if (transform.position == positions[0])
                {
                    currentPosition = 0;
                    StartCoroutine(stop());
                }
            }
            else 
            {
                transform.position = Vector3.Lerp(transform.position, positions[currentPosition + 1], speed * Time.deltaTime);
                if (transform.position == positions[currentPosition + 1])
                {
                    currentPosition++;
                    StartCoroutine(stop());
                }
            }
        }
    }
    IEnumerator stop()
    {
        isIdle = true;
        yield return new WaitForSeconds(timeToWait);
        isIdle = false;
    }
}
