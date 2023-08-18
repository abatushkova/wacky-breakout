using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    #region Fields

    // score support
    int points;
    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();

    // destruction support
    BlockDestroyedEvent blockDestroyedEvent = new BlockDestroyedEvent();

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
        EventManager.AddBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="other"></param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            pointsAddedEvent.Invoke(points);
            EventManager.RemovePointsAddedInvoker(this);
            blockDestroyedEvent.Invoke();
            EventManager.RemoveBlockDestroyedInvoker(this);
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }

    #endregion
}
