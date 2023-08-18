using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Goes to difficulty menu
    /// </summary>
    public void GoToDifficultyMenu()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    /// <summary>
    /// /// Shows help menu
    /// </summary>
    public void ShowHelp()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Exits game
    /// </summary>
    public void ExitGame()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        Application.Quit();
    }
}
