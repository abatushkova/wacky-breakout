using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields
    static ConfigurationData configData;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets seconds the ball lives
    /// </summary>
    /// <value></value>
    public static float BallLifeSeconds
    {
        get { return configData.BallLifeSeconds; }
    }

    /// <summary>
    /// Gets min seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MinSpawnSeconds
    {
        get { return configData.MinSpawnSeconds; }
    }

    /// <summary>
    /// Gets max seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MaxSpawnSeconds
    {
        get { return configData.MaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    /// <value></value>
    public static int BallsPerGame
    {
        get { return configData.BallsPerGame; }
    }

    /// <summary>
    /// Gets points of standard block
    /// </summary>
    /// <value></value>
    public static int StandardBlockPoints
    {
        get { return configData.StandardBlockPoints; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}
