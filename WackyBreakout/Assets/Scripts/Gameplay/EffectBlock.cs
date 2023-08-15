using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : Block
{
    #region Fields

    [SerializeField] Sprite freezeSprite;
    [SerializeField] Sprite speedSprite;
    EffectName effect;
    int duration;
    FreezeEvent freezeEvent;

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
                duration = ConfigurationUtils.FreezeSeconds;
                freezeEvent = new FreezeEvent();
                EventManager.AddFreezeInvoker(this);
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
    protected override void Start()
    {
        base.Start();
        Points = ConfigurationUtils.EffectBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Detects collision with ball
    /// </summary>
    /// <param name="other"></param>
    protected override void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            base.OnCollisionEnter2D(other);

            if (effect == EffectName.Freezer) {
                freezeEvent.Invoke(duration);
                EventManager.RemoveFreezeInvoker(this);
            }
        }
    }

    /// <summary>
    /// Adds given listener to freeze event
    /// </summary>
    /// <param name="listener"></param>
    public void AddFreezeListener(UnityAction<float> listener)
    {
        freezeEvent.AddListener(listener);
    }

    #endregion
}
