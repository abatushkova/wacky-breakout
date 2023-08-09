using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    Timer deathTimer;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        // get ball moving at 20 degree (bottom-left)
        float angle = 90 * Mathf.Rad2Deg;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // destroy ball
        if (deathTimer.Finished) {
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
    #endregion
}
