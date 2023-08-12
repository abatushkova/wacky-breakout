using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields

    Timer delayTimer;
    Timer deathTimer;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // start delay timer
        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.Duration = 1;
        delayTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // move ball after delay
        if (delayTimer.Finished)
        {
            delayTimer.Stop();
            StartMoving();
        }

        // spawn new ball, destroy prev ball
        if (deathTimer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            float colliderHalfSize = gameObject.GetComponent<CircleCollider2D>().radius / 2;
            if (transform.position.y - colliderHalfSize < ScreenUtils.ScreenBottom)
            {
                HUD.LoseBall();
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
            }
            Destroy(gameObject);
        }
    }

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
    /// Starts ball moving
    /// </summary>
    private void StartMoving()
    {
        // get ball moving
        float angle = Random.Range(-90, -100) * Mathf.Rad2Deg;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    #endregion
}
