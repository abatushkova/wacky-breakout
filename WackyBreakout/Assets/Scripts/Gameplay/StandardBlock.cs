using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    #region Fields

    [SerializeField] Sprite sprite01;
    [SerializeField] Sprite sprite02;
    [SerializeField] Sprite sprite03;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // set points to standard block
        Points = ConfigurationUtils.StandardBlockPoints;

        // set random sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = sprite01;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = sprite02;
        }
        else
        {
            spriteRenderer.sprite = sprite03;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
