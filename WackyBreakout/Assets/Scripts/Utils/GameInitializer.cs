using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour
{
    // Awake is called before Start
    void Awake()
    {
        // initialize screen utils, config utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
        DifficultyUtils.Initialize();
    }
}
