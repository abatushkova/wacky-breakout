using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject prefabBall;

    // spawn support
    Timer spawnTimer;
    float spawnRange;

    // collision-free support
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // create and destroy ball to calc spawn min-max location
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        CircleCollider2D collider = tempBall.GetComponent<CircleCollider2D>();
        float ballColliderHalfSize = collider.radius / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfSize,
            tempBall.transform.position.y - ballColliderHalfSize
        );
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfSize,
            tempBall.transform.position.y + ballColliderHalfSize
        );
        Destroy(tempBall);

        // init, start spawn timer
        spawnRange = ConfigurationUtils.MaxSpawnSeconds - ConfigurationUtils.MinSpawnSeconds;
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();

        // spawn first ball
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn ball, restart timer
        if (spawnTimer.Finished)
        {
            retrySpawn = false;
            SpawnBall();
            spawnTimer.Duration = GetSpawnDelay();
            spawnTimer.Run();
        }

        // try again if spawn still pending
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    /// <summary>
    /// Spawns a ball
    /// </summary>
    public void SpawnBall()
    {
        // avoid balls collision on spawn
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null) {
            retrySpawn = false;
            Instantiate<GameObject>(prefabBall);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// Gets spawn dela in seconds for next ball spawn
    /// </summary>
    private float GetSpawnDelay()
    {
        return ConfigurationUtils.MinSpawnSeconds + Random.value * spawnRange;
    }

    #endregion
}
