using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelCountdownScript : MonoBehaviour
{
    public float StartingTime;
    public Text CountdownText;
    public UnityEvent OnCountdownFinished;

    private float _timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        // Restart the countdown
        _timeRemaining = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Update countdown by subtracting deltaTime
        if (_timeRemaining > 0) // If the 
        {
            _timeRemaining -= Time.deltaTime;
        } 
        else
        {
            OnCountdownFinished?.Invoke();
        }

        // Update the Countdown text to show the remaining
        // time in seconds
        CountdownText.text = string.Format("{0}s",(int)_timeRemaining);
    }
}
