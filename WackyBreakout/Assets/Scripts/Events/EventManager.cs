using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    // ball-died support
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    // ball-lost support
    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners = new List<UnityAction>();

    #endregion

    #region Methods

    /// <summary>
    /// Adds all listeners to invoker, invoker to list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Adds listener to all invokers, listener to list
    /// </summary>
    /// <param name="listener"></param>
    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Removes invoker from list
    /// </summary>
    /// <param name="invoker"></param>
    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }

    /// <summary>
    /// Adds all listeners to invoker, invoker to list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Add(invoker);
        foreach (UnityAction listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds listener to all invokers, listener to list
    /// </summary>
    /// <param name="listener"></param>
    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListeners.Add(listener);
        foreach (Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Removes invoker from list
    /// </summary>
    /// <param name="invoker"></param>
    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }

    #endregion
}
