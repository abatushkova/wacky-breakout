using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    #region Fields

    Timer delayTimer;
    Timer deathTimer;
    BallDiedEvent ballDiedEvent = new BallDiedEvent();
    BallLostEvent ballLostEvent = new BallLostEvent();

    #endregion

    #region Private Methods

    // Start is called before the first frame update
    void Start()
    {
        // start delay timer
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 1;
        delayTimer.Run();
        delayTimer.AddTimerFinishedListener(HandleDelayTimerFinished);

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);

        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Spawn new ball, destroy self when out of game
    private void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            float colliderHalfSize = gameObject.GetComponent<CircleCollider2D>().radius / 2;
            if (transform.position.y - colliderHalfSize < ScreenUtils.ScreenBottom)
            {
                ballLostEvent.Invoke();
            }
            DestroyBall();
        }
    }

    /// <summary>
    /// Starts ball moving
    /// </summary>
    private void StartMoving()
    {
        float angle = Random.Range(-90, -100) * Mathf.Rad2Deg;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Destroys ball
    /// </summary>
    private void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        Destroy(gameObject);
    }

    /// <summary>
    /// Invokes death-timer event
    /// </summary>
    private void HandleDeathTimerFinished()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }

    /// <summary>
    /// Stops delay timer, starts ball moving
    /// </summary>
    private void HandleDelayTimerFinished()
    {
        delayTimer.Stop();
        StartMoving();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Sets ball direction to given direction
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// Adds given listener to BallDiedEvent
    /// </summary>
    /// <param name="listener"></param>
    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds given listener to BallLostEvent
    /// </summary>
    /// <param name="listener"></param>
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    #endregion
}
