using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBlock : Block
{
    #region Fields

    [SerializeField] Sprite freezeSprite;
    [SerializeField] Sprite speedSprite;
    EffectName effect;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the effect to pickup
    /// /// </summary>
    /// <value></value>
    public EffectName Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == EffectName.Freezer)
            {
                spriteRenderer.sprite = freezeSprite;
            }
            else
            {
                spriteRenderer.sprite = speedSprite;
            }
        }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        Points = ConfigurationUtils.EffectBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion
}
