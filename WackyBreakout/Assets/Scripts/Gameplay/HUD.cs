using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject ballsLeftTextObject;
    [SerializeField] GameObject scoreTextObject;

    // balls support
    const string BallsLeftPrefix = "Balls left: ";
    static int ballsLeft = 0;
    static TextMeshProUGUI ballsLeftText;

    // score support
    const string ScorePrefix = "Score: ";
    static int score = 0;
    static TextMeshProUGUI scoreText;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // set number of balls left
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = ballsLeftTextObject.GetComponent<TextMeshProUGUI>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();

        // set score
        score = 0;
        scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = ScorePrefix + score.ToString();

        // add listeners
        EventManager.AddBallLostListener(LoseBall);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Reduce the number of balls left
    /// </summary>
    private void LoseBall()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
    }

    /// <summary>
    /// Add given points to score
    /// </summary>
    /// <param name="points"></param>
    public static void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }

    #endregion
}
