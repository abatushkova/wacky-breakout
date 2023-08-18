using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Goes to main menu
    /// </summary>
    public void GoBack()
    {
        AudioManager.Play(AudioName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
