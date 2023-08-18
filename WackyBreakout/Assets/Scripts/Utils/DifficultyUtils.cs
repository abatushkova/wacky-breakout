using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DifficultyUtils
{
    #region Fields

    static DifficultyName difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    public static float MinSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyName.Easy:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
                case DifficultyName.Medium:
                    return ConfigurationUtils.MediumMinSpawnSeconds;
                case DifficultyName.Hard:
                    return ConfigurationUtils.HardMinSpawnSeconds;
                default:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
            }
        }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    public static float MaxSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyName.Easy:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
                case DifficultyName.Medium:
                    return ConfigurationUtils.MediumMaxSpawnSeconds;
                case DifficultyName.Hard:
                    return ConfigurationUtils.HardMaxSpawnSeconds;
                default:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
            }
        }
    }

    /// <summary>
    /// Gets the impulse force for balls
    /// </summary>
    /// <value>ball impulse force</value>
    public static float BallImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case DifficultyName.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;
                case DifficultyName.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;
                case DifficultyName.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;
                default:
                    return ConfigurationUtils.EasyBallImpulseForce;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddGameStartedListener(HandleGameStartedEvent);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Sets the difficulty and starts the game
    /// </summary>
    /// <param name="gameDifficulty">difficulty</param>
    private static void HandleGameStartedEvent(DifficultyName gameDifficulty)
    {
        difficulty = gameDifficulty;
        SceneManager.LoadScene("Gameplay");
    }

    #endregion
}
