using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    /// <summary>
    /// Gets whether or not the speed effect is active
    /// </summary>
    /// <value><c>true</c> if speed effect active; otherwise, <c>false</c>.</value>
    public static bool SpeedEffectActive
    {
        get { return GetSpeedEffectMonitor().SpeedEffectActive; }
    }

    /// <summary>
    /// Gets how many seconds are left in the speed effect
    /// </summary>
    /// <value>speed effect seconds left</value>
    public static float SpeedEffectSecondsLeft
    {
        get { return GetSpeedEffectMonitor().SpeedEffectSecondsLeft; }
    }

    /// <summary>
    /// Gets the speed factor for the speed effect
    /// </summary>
    /// <value>speed factor</value>
    public static float SpeedFactor
    {
        get { return GetSpeedEffectMonitor().SpeedFactor; }
    }

    /// <summary>
    /// Gets the SpeedEffectMonitor attached to the main camera
    /// </summary>
    /// <returns>speed effect monitor</returns>
    static SpeedEffectMonitor GetSpeedEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedEffectMonitor>();
    }
}
