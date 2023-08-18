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

    // points-add support
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners = new List<UnityAction<int>>();

    // freeze effect support
    static List<EffectBlock> freezeInvokers = new List<EffectBlock>();
    static List<UnityAction<float>> freezeListeners = new List<UnityAction<float>>();

    // speed effect support
    static List<EffectBlock> speedInvokers = new List<EffectBlock>();
    static List<UnityAction<float, float>> speedListeners =
        new List<UnityAction<float, float>>();

    // game started support
    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<DifficultyName>> gameStartedListeners =
        new List<UnityAction<DifficultyName>>();

    // last ball lost support
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners = new List<UnityAction>();

    // block destroyed support
    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners = new List<UnityAction>();

    #endregion

    #region BallDied methods

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

    #endregion

    #region BallLost methods

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

    #region PointsAdded methods

    /// <summary>
    /// Adds all listeners to invoker, invoker to list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds listener to all invokers, listener to list
    /// </summary>
    /// <param name="listener"></param>
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Removes invoker from list
    /// </summary>
    /// <param name="invoker"></param>
    public static void RemovePointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Remove(invoker);
    }

    #endregion

    #region Freeze methods

    /// <summary>
    /// Adds all listeners to invoker, invoker to list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddFreezeInvoker(EffectBlock invoker)
    {
        freezeInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezeListeners)
        {
            invoker.AddFreezeListener(listener);
        }
    }

    /// <summary>
    /// Adds listener to all invokers, listener to list
    /// </summary>
    /// <param name="listener"></param>
    public static void AddFreezeListener(UnityAction<float> listener)
    {
        freezeListeners.Add(listener);
        foreach (EffectBlock invoker in freezeInvokers)
        {
            invoker.AddFreezeListener(listener);
        }
    }

    /// <summary>
    /// Removes invoker from list
    /// </summary>
    /// <param name="invoker"></param>
    public static void RemoveFreezeInvoker(EffectBlock invoker)
    {
        freezeInvokers.Remove(invoker);
    }

    #endregion

    #region Speed methods

    /// <summary>
    /// Adds all listeners to invoker, invoker to list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSpeedInvoker(EffectBlock invoker)
    {
        speedInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedListeners)
        {
            invoker.AddSpeedListener(listener);
        }
    }

    /// <summary>
    /// Adds listener to all invokers, listener to list
    /// </summary>
    /// <param name="listener"></param>
    public static void AddSpeedListener(UnityAction<float, float> listener)
    {
        speedListeners.Add(listener);
        foreach (EffectBlock invoker in speedInvokers)
        {
            invoker.AddSpeedListener(listener);
        }
    }

    /// <summary>
    /// Removes invoker from list
    /// </summary>
    /// <param name="invoker"></param>
    public static void RemoveSpeedInvoker(EffectBlock invoker)
    {
        speedInvokers.Remove(invoker);
    }

    /// <summary>
    /// Removes listener from all invokers, listener from list
    /// </summary>
    /// <param name="listener"></param>
    public static void RemoveSpeedListener(UnityAction<float, float> listener)
    {
        speedListeners.Remove(listener);
        foreach (EffectBlock invoker in speedInvokers)
        {
            invoker.RemoveSpeedListener(listener);
        }
    }

    #endregion

    #region GameStarted methods

    /// <summary>
    /// Adds the given script as a game started invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);
        foreach (UnityAction<DifficultyName> listener in gameStartedListeners)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a game started listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddGameStartedListener(UnityAction<DifficultyName> listener)
    {
        gameStartedListeners.Add(listener);
        foreach (DifficultyMenu invoker in gameStartedInvokers)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    #endregion

    #region LastBallLost methods

    /// <summary>
    /// Adds the given script as a last ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a last ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    #endregion

    #region BlockDestroyed methods

    /// <summary>
    /// Adds the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a block destroyed listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBlockDestroyedInvoker(Block invoker)
    {
        // remove invoker from list
        blockDestroyedInvokers.Remove(invoker);
    }

    #endregion
}
