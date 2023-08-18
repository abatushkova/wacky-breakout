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
    /// Gets seconds the ball lives
    /// </summary>
    /// <value></value>
    public static float BallLifeSeconds
    {
        get { return configData.BallLifeSeconds; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    public static float EasyBallImpulseForce
    {
        get { return configData.EasyBallImpulseForce; }
    }

    /// <summary>
    /// Gets min seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float EasyMinSpawnSeconds
    {
        get { return configData.EasyMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets max seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float EasyMaxSpawnSeconds
    {
        get { return configData.EasyMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    public static float MediumBallImpulseForce
    {
        get { return configData.MediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets min seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MediumMinSpawnSeconds
    {
        get { return configData.MediumMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets max seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float MediumMaxSpawnSeconds
    {
        get { return configData.MediumMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the ball impulse force
    /// </summary>
    public static float HardBallImpulseForce
    {
        get { return configData.HardBallImpulseForce; }
    }

    /// <summary>
    /// Gets min seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float HardMinSpawnSeconds
    {
        get { return configData.HardMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets max seconds for a ball to spawn
    /// </summary>
    /// <value></value>
    public static float HardMaxSpawnSeconds
    {
        get { return configData.HardMaxSpawnSeconds; }
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

    /// <summary>
    /// Gets points of bonus block
    /// </summary>
    /// <value></value>
    public static int BonusBlockPoints
    {
        get { return configData.BonusBlockPoints; }
    }

    /// <summary>
    /// Gets points of effect block
    /// </summary>
    /// <value></value>
    public static int EffectBlockPoints
    {
        get { return configData.EffectBlockPoints; }
    }

    /// <summary>
    /// Gets probability of adding standard block
    /// </summary>
    /// <value></value>
    public static float StandardBlockProbability
    {
        get { return configData.StandardBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding bonus block
    /// </summary>
    /// <value></value>
    public static float BonucBlockProbability
    {
        get { return configData.BonucBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding freeze block
    /// </summary>
    /// <value></value>
    public static float FreezeBlockProbability
    {
        get { return configData.FreezeBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding speed block
    /// </summary>
    /// <value></value>
    public static float SpeedBlockProbability
    {
        get { return configData.SpeedBlockProbability; }
    }

    /// <summary>
    /// Gets duration of freeze effect
    /// </summary>
    /// <value></value>
    public static float FreezeSeconds
    {
        get { return configData.FreezeSeconds; }
    }

    /// <summary>
    /// Gets duration of speed effect
    /// </summary>
    /// <value></value>
    public static float SpeedSeconds
    {
        get { return configData.SpeedSeconds; }
    }

    /// <summary>
    /// Gets speed factor
    /// </summary>
    /// <value></value>
    public static float SpeedFactor
    {
        get { return configData.SpeedFactor; }
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
