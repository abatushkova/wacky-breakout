using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffectMonitor : MonoBehaviour
{
    #region Fields

    // speed effect support
    Timer speedEffectTimer;
    float speedFactor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets whether or not the speed effect is active
    /// </summary>
    /// <value><c>true</c> if speed effect active; otherwise, <c>false</c>.</value>
    public bool SpeedEffectActive
    {
        get { return speedEffectTimer.Running; }
    }

    /// <summary>
    /// Gets how many seconds are left in the speed effect
    /// </summary>
    /// <value>speed effect seconds left</value>
    public float SpeedEffectSecondsLeft
    {
        get { return speedEffectTimer.SecondsLeft; }
    }

    /// <summary>
    /// Gets the speed factor for the speed effect
    /// </summary>
    /// <value>speed factor</value>
    public float SpeedFactor
    {
        get { return speedFactor; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        speedEffectTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedListener(HandleSpeedEvent);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // stop speed timer as appropriate
        if (speedEffectTimer.Finished)
        {
            speedEffectTimer.Stop();
            speedFactor = 1;
        }
    }

    /// <summary>
    /// Handles the speed effect activated event
    /// </summary>
    /// <param name="duration">duration of the speed effect</param>
    /// <param name="speedFactor">the speed factor</param>
    private void HandleSpeedEvent(float duration, float speedFactor)
    {
        // run or add time to timer
        if (!speedEffectTimer.Running)
        {
            this.speedFactor = speedFactor;
            speedEffectTimer.Duration = duration;
            speedEffectTimer.Run();
        }
        else
        {
            speedEffectTimer.AddTime(duration);
        }
    }

    #endregion
}
