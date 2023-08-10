using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Fields

    int points;

    #endregion

    #region Properties

    /// <summary>
    /// Sets points the block is worth
    /// </summary>
    /// <value></value>
    protected int Points
    {
        set { points = value; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            HUD.AddPoints(points);
            Destroy(gameObject);
        }
    }

    #endregion
}
