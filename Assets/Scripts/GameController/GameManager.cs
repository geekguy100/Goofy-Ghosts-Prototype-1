/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Handles managing game state and scene loading.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The GameManager's control scheme.
    /// </summary>
    private GameManagerInput controls;

    /// <summary>
    /// True if the game is paused.
    /// </summary>
    private bool paused;

    [SerializeField] private SceneLoaderSO sceneLoader;

    [Tooltip("Channel to broadcast the pause game event to.")]
    [SerializeField] private BoolChannelSO pauseGameChannel;

    [Tooltip("Channel to receive calls about the player's death.")]
    [SerializeField] private VoidChannelSO playerDeathChannel;

    #region -- Subscribing / Unsubscribing to Events --
    private void OnEnable()
    {
        controls.GameController.PauseGame.performed += OnPauseGame;
        controls.GameController.PauseGame.Enable();

        playerDeathChannel.OnEventRaised += RespawnPlayer;
    }

    private void OnDisable()
    {
        controls.GameController.PauseGame.Disable();

        playerDeathChannel.OnEventRaised -= RespawnPlayer;
    }
    #endregion

    private void Awake()
    {
        controls = new GameManagerInput();
    }

    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            sceneLoader.LoadSceneAsyncAdditive("MainMenu", false);
        }
    }

    /// <summary>
    /// Invoked when the pause button is pressed.
    /// </summary>
    /// <param name="context">The input system's callback context.</param>
    private void OnPauseGame(InputAction.CallbackContext context)
    {
        paused = !paused;
        pauseGameChannel.RaiseEvent(paused);

        // Freezes the game if paused.
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void RespawnPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }
}