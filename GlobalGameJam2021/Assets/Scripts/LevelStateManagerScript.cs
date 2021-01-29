using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManagerScript : MonoBehaviour
{
    // Create state enums
    private enum LevelState
    {
        INTRO,          // Introduction state
        GAMEPLAY,       // Gameplay state
        WIN,            // Win state
        LOSS            // Lose state
    }

    // Variable containing the current level state
    private LevelState currentState { get; set; }

    // Set the LevelState to "WIN"
    public void SetPlayerWin()
    {
        currentState = LevelState.WIN;  // Update state
        Debug.Log("Game WON");          // Print Debug Message
    }

    // Set the LevelState to "LOSS"
    public void SetPlayerLoose()
    {
        currentState = LevelState.LOSS;  // Update state
        Debug.Log("Game LOST");          // Print Debug Message
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialise manager variables
        currentState = LevelState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        // Update paths based on current state enum
        switch (currentState)
        {
        case LevelState.INTRO:
            // INTRO update
            break;

        case LevelState.GAMEPLAY:
            // GAMEPLAY update
            break;

        case LevelState.WIN:
            // WIN update
            break;

        case LevelState.LOSS:
            // LOSS update
            break;
        }
    }
}