using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Goes to main menu
    /// </summary>
    public void GoBack()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}
