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

    // speed support
    Rigidbody2D rb2d;
    Timer speedTimer;
    float speedFactor;

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

        // start speed timer
        speedTimer = gameObject.AddComponent<Timer>();
        speedTimer.AddTimerFinishedListener(HandleSpeedTimerFinished);
        EventManager.AddSpeedListener(HandleSpeedEvent);

        rb2d = GetComponent<Rigidbody2D>();

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
            ConfigurationUtils.EasyBallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.EasyBallImpulseForce * Mathf.Sin(angle));

        if (EffectUtils.SpeedEffectActive)
        {
            StartSpeedEffect(EffectUtils.SpeedEffectSecondsLeft, EffectUtils.SpeedFactor);
            force *= speedFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Destroys ball
    /// </summary>
    private void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        EventManager.RemoveSpeedListener(HandleSpeedEvent);
        Destroy(gameObject);
    }

    /// <summary>
    /// Invokes death timer event
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

    /// <summary>
    /// Returns ball to normal speed
    /// </summary>
    private void HandleSpeedTimerFinished()
    {
        speedTimer.Stop();
        rb2d.velocity *= 1 / speedFactor;
    }

    /// <summary>
    /// Speeds up ball, adds time to speed timer
    /// </summary>
    /// <param name="duration">duration of speed effect</param>
    /// <param name="speedFactor"></param>
    private void HandleSpeedEvent(float duration, float speedFactor)
    {
        if (!speedTimer.Running)
        {
            StartSpeedEffect(duration, speedFactor);
            rb2d.velocity *= speedFactor;
        }
        else
        {
            speedTimer.AddTime(duration);
        }
    }

    /// <summary>
    /// Starts speed effect
    /// </summary>
    /// <param name="duration">duration of speed effect</param>
    /// <param name="speedFactor"></param>
    private void StartSpeedEffect(float duration, float speedFactor)
    {
        this.speedFactor = speedFactor;
        speedTimer.Duration = duration;
        speedTimer.Run();
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
