using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Reference to the Game-End text
    public Text GameEndText;

    // GameEndText scale rate
    public float GameEndTextScaleRate;

    // GaneEndText scale value
    private Vector3 _gameEndTextScale;

    private float _gameOverTimeElapsed = 0;

    // Level State enum
    LevelState currentState;

    // Set the LevelState to "WIN"
    public void SetPlayerWin()
    {
        currentState = LevelState.WIN;  // Update state
        GameEndText.text = "You Win!";
        PlayerMovement plyMovementComponent = PlayerObject.GetComponent<PlayerMovement>();
        plyMovementComponent.isEnabled = false;
        Debug.Log("Game WON");          // Print Debug Message
    }

    // Set the LevelState to "LOSS"
    public void SetPlayerLoose()
    {
        currentState = LevelState.LOSS;  // Update state
        GameEndText.text = "You Loose!";
        PlayerMovement plyMovementComponent = PlayerObject.GetComponent<PlayerMovement>();
        plyMovementComponent.isEnabled = false;
        Debug.Log("Game LOST");          // Print Debug Message
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialise manager variables
        currentState = LevelState.GAMEPLAY;

        // Spawn Player at one of the spawn points
        PlayerObject.transform.position = PlayerSpawnPoints[Random.Range(0, PlayerSpawnPoints.Length)].transform.position;

        // Update the game end text
        _gameEndTextScale = new Vector3(0.0f, 0.0f, 0.0f);
        GameEndText.transform.localScale = _gameEndTextScale;
    }

    // stateManager update function
    void Update()
    {
        // Display the game-end text on the players UI
        if (currentState == LevelState.WIN || currentState == LevelState.LOSS) // If the game has ended...
        {
            _gameOverTimeElapsed += Time.deltaTime;

            // Check to see if the UI text has finished scaling over-time
            if (_gameEndTextScale.x < 1.0f) // If the scaling has finihsed...
            {
                // Increment scale
                _gameEndTextScale.x += GameEndTextScaleRate * Time.deltaTime;
                _gameEndTextScale.y += GameEndTextScaleRate * Time.deltaTime;
                _gameEndTextScale.z += GameEndTextScaleRate * Time.deltaTime;
                GameEndText.transform.localScale = _gameEndTextScale;
            } 

            // Time elapsed check
            if(_gameOverTimeElapsed >= 5.0f) // If the time passed since the game has finished surpassed 5 seconds...
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}