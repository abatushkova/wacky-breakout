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
    float paddleMoveUnitsPerSecond = 15;
    float ballLifeSeconds = 10;
    float easyBallImpulseForce = 200;
    float easyMinSpawnSeconds = 5;
    float easyMaxSpawnSeconds = 10;
    float mediumBallImpulseForce = 300;
    float mediumMinSpawnSeconds = 3;
    float mediumMaxSpawnSeconds = 7;
    float hardBallImpulseForce = 400;
    float hardMinSpawnSeconds = 2;
    float hardMaxSpawnSeconds = 5;
    int ballsPerGame = 5;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int effectBlockPoints = 5;
    float standardBlockProbability = 0.7f;
    float bonusBlockProbability = 0.2f;
    float freezeBlockProbability = 0.05f;
    float speedBlockProbability = 0.05f;
    float freezeSeconds = 2;
    float speedSeconds = 2;
    float speedFactor = 2;


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
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float EasyBallImpulseForce
    {
        get { return easyBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float EasyMinSpawnSeconds
    {
        get { return easyMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float EasyMaxSpawnSeconds
    {
        get { return easyMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float MediumBallImpulseForce
    {
        get { return mediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MediumMinSpawnSeconds
    {
        get { return mediumMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MediumMaxSpawnSeconds
    {
        get { return mediumMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the easy impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float HardBallImpulseForce
    {
        get { return hardBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float HardMinSpawnSeconds
    {
        get { return hardMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float HardMaxSpawnSeconds
    {
        get { return hardMaxSpawnSeconds; }
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
    /// Gets duration of freeze effect
    /// </summary>
    /// <value></value>
    public float FreezeSeconds
    {
        get { return freezeSeconds; }
    }

    /// <summary>
    /// Gets duration of speed effect
    /// </summary>
    /// <value></value>
    public float SpeedSeconds
    {
        get { return speedSeconds; }
    }

    /// <summary>
    /// Gets speed factor
    /// </summary>
    /// <value></value>
    public float SpeedFactor
    {
        get { return speedFactor; }
    }

    #endregion

    #region Methods

    private void SetConfigDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        // code below assumes we know the order
        // in which values appear in input string
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballLifeSeconds = float.Parse(values[1]);
        easyBallImpulseForce = float.Parse(values[2]);
        easyMinSpawnSeconds = float.Parse(values[3]);
        easyMaxSpawnSeconds = float.Parse(values[4]);
        mediumBallImpulseForce = float.Parse(values[5]);
        mediumMinSpawnSeconds = float.Parse(values[6]);
        mediumMaxSpawnSeconds = float.Parse(values[7]);
        hardBallImpulseForce = float.Parse(values[8]);
        hardMinSpawnSeconds = float.Parse(values[9]);
        hardMaxSpawnSeconds = float.Parse(values[10]);
        ballsPerGame = int.Parse(values[11]);
        standardBlockPoints = int.Parse(values[12]);
        bonusBlockPoints = int.Parse(values[13]);
        effectBlockPoints = int.Parse(values[14]);
        standardBlockProbability = float.Parse(values[15]) / 100;
        bonusBlockProbability = float.Parse(values[16]) / 100;
        freezeBlockProbability = float.Parse(values[17]) / 100;
        speedBlockProbability = float.Parse(values[18]) / 100;
        freezeSeconds = float.Parse(values[19]);
        speedSeconds = float.Parse(values[20]);
        speedFactor = float.Parse(values[21]);
    }

    #endregion
}
