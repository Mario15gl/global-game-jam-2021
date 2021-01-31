using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // Reference to Player object
    public GameObject PlayerObject;

    // Collection of Player Spawn points
    public GameObject[] PlayerSpawnPoints;

    // Level State enum
    LevelState currentState;

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

        // Spawn Player at one of the spawn points
        PlayerObject.transform.position = PlayerSpawnPoints[Random.Range(0, PlayerSpawnPoints.Length)].transform.position;
    }
}