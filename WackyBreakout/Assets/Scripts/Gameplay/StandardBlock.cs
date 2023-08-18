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

    #region Methods

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Points = ConfigurationUtils.StandardBlockPoints;
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

    #endregion
}
