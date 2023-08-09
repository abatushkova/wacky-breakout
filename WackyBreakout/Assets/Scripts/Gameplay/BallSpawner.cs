using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject prefabBall;
    #endregion

    #region  Methods
    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(prefabBall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
