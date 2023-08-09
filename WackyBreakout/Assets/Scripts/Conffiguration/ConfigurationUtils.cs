using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return 10; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    public static float BallImpulseForce
    {
        get { return 200; }
    }

    /// <summary>
    /// Gets seconds the ball lives
    /// </summary>
    /// <value></value>
    public static float BallLifeSeconds
    {
        get { return 10; }
    }

    /// <summary>
    /// Gets min seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MinSpawnSeconds
    {
        get { return 5; }
    }

    /// <summary>
    /// Gets max seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MaxSpawnSeconds
    {
        get { return 10; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {

    }
}
