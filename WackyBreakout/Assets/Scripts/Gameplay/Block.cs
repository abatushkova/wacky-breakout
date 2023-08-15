using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    #region Fields

    int points;
    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();

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
    protected virtual void Start()
    {
        // add listeners
        EventManager.AddPointsAddedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            pointsAddedEvent.Invoke(points);
            EventManager.RemovePointsAddedInvoker(this);
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    #endregion
}
