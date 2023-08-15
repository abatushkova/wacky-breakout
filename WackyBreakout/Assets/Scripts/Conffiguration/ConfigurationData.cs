using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int ballsPerGame = 5;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int effectBlockPoints = 5;
    float standardBlockProbability = 0.7f;
    float bonusBlockProbability = 0.2f;
    float freezeBlockProbability = 0.05f;
    float speedBlockProbability = 0.05f;
    int freezeSeconds = 2;

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigDataFileName
            ));

            // get key-value input data
            string keys = input.ReadLine();
            string values = input.ReadLine();

            SetConfigDataFields(values);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    /// <value></value>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    /// <summary>
    /// Gets points of standard block
    /// </summary>
    /// <value></value>
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// Gets points of bonus block
    /// </summary>
    /// <value></value>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// Gets points of effect block
    /// </summary>
    /// <value></value>
    public int EffectBlockPoints
    {
        get { return effectBlockPoints; }
    }

    /// <summary>
    /// Gets probability of adding standard block
    /// </summary>
    /// <value></value>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding bonus block
    /// </summary>
    /// <value></value>
    public float BonucBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding freeze block
    /// </summary>
    /// <value></value>
    public float FreezeBlockProbability
    {
        get { return freezeBlockProbability; }
    }

    /// <summary>
    /// Gets probability of adding speed block
    /// </summary>
    /// <value></value>
    public float SpeedBlockProbability
    {
        get { return speedBlockProbability; }
    }

    /// <summary>
    /// Gets seconds of freeze effect
    /// </summary>
    /// <value></value>
    public int FreezeSeconds
    {
        get { return freezeSeconds; }
    }

    #endregion

    #region Methods

    private void SetConfigDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        // code below assumes we know the order
        // in which values appear in input string
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        ballsPerGame = int.Parse(values[5]);
        standardBlockPoints = int.Parse(values[6]);
        bonusBlockPoints = int.Parse(values[7]);
        effectBlockPoints = int.Parse(values[8]);
        standardBlockProbability = float.Parse(values[9]) / 100;
        bonusBlockProbability = float.Parse(values[10]) / 100;
        freezeBlockProbability = float.Parse(values[11]) / 100;
        speedBlockProbability = float.Parse(values[12]) / 100;
        freezeSeconds = int.Parse(values[13]);
    }

    #endregion
}
