using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Fields

    Rigidbody2D rb2d;
    float colliderHalfWidth;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    // freeze effect support
    bool frozen = false;
    Timer freezeTimer;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        colliderHalfWidth = bc2d.size.x / 2;

        // freeze timer
        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(HandleFreezeTimerFinished);
        EventManager.AddFreezeListener(HandleFreezeEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is alled 50 times per second
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!frozen && horizontalInput != 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")
            && TopCollision(collision))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                collision.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                colliderHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ball = collision.gameObject.GetComponent<Ball>();
            ball.SetDirection(direction);
        }
    }

    /// <summary>
    /// Checks for collision on paddle top
    /// </summary>
    /// <param name="collision"></param>
    /// <returns><c>true</c> if collision was on paddle top, <c>false</c> - otherwise</returns>
    private bool TopCollision(Collision2D collision)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        collision.GetContacts(contacts);
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    /// <summary>
    /// Calculates an x position to clamp the paddle in the screen
    /// </summary>
    /// <param name="x">position x to clamp</param>
    /// <returns>clamped position x</returns>
    private float CalculateClampedX(float x)
    {
        if (x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        if (x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        return x;
    }

    /// <summary>
    /// Unfreezes paddlee, stops freeze-timer
    /// </summary>
    private void HandleFreezeTimerFinished() {
        frozen = false;
        freezeTimer.Stop();
    }

    /// <summary>
    /// Handles freeze-timer event
    /// </summary>
    /// <param name="duration"></param>
    private void HandleFreezeEvent(float duration) {
        frozen = true;
        if (!freezeTimer.Running) {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else {
            freezeTimer.AddTime(duration);
        }
    }

    #endregion
}
