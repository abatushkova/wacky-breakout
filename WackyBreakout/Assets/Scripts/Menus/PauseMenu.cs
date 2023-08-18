using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    /// <summary>
    /// Resumes the paused game
    /// </summary>
    public void ResumeGame()
    {
        // unpause game and destroy menu
        AudioManager.Play(AudioName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Quits the paused game
    /// </summary>
    public void QuitGame()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
