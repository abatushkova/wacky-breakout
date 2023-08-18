using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Goes to difficulty menu
    /// </summary>
    public void GoToDifficultyMenu()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    /// <summary>
    /// /// Shows help menu
    /// </summary>
    public void ShowHelp()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Exits game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
