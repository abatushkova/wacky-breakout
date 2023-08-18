using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    #region Fields

    // events invoked by the class
    GameStartedEvent gameStartedEvent = new GameStartedEvent();

    #endregion

    #region Unity methods

    // Start is called before the first frame update
    void Start()
    {
        // add invoker to event manager
        EventManager.AddGameStartedInvoker(this);
    }

    #endregion

    #region Public methods
    /// <summary>
    /// Adds the given listener for the game started event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddGameStartedListener(UnityAction<DifficultyName> listener)
    {
        gameStartedEvent.AddListener(listener);
    }

    /// <summary>
    /// Starts an easy game
    /// </summary>
    public void StartEasyGame()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        gameStartedEvent.Invoke(DifficultyName.Easy);
    }

    /// <summary>
    /// Starts a medium game
    /// </summary>
    public void StartMediumGame()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        gameStartedEvent.Invoke(DifficultyName.Medium);
    }

    /// <summary>
    /// Starts a hard game
    /// </summary>
    public void StartHardGame()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        gameStartedEvent.Invoke(DifficultyName.Hard);
    }

    #endregion
}
