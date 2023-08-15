using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject prefabPaddle;
    [SerializeField] GameObject prefabStandardBlock;
    [SerializeField] GameObject prefabBonusBlock;
    [SerializeField] GameObject prefabEffectBlock;

    // config support
    float standardProbability = 0;
    float bonusProbability = 0;
    float freezeProbability = 0;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // add paddle to scene
        Instantiate<GameObject>(prefabPaddle);

        // set probabilities
        standardProbability = ConfigurationUtils.StandardBlockProbability;
        bonusProbability = ConfigurationUtils.BonucBlockProbability;
        freezeProbability = ConfigurationUtils.FreezeBlockProbability;

        // get block width, height
        GameObject tempBlock = Instantiate<GameObject>(prefabPaddle);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        // calc block per row, left block centers a row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float levelWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - levelWidth) / 2 +
            blockWidth / 2;
        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        // add rows
        Vector2 currPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < blocksPerRow; col++)
            {
                PlaceBlock(currPosition);
                currPosition.x += blockWidth;
            }

            // move to next row
            currPosition.x = leftBlockOffset;
            currPosition.y += blockHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Places random block at given position
    /// </summary>
    /// <param name="position"></param>
    private void PlaceBlock(Vector2 position)
    {
        float randomProbability = Random.value;
        if (randomProbability < standardProbability)
        {
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
        }
        else if (randomProbability < standardProbability + bonusProbability)
        {
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        }
        else
        {
            // select effect block
            GameObject effectBlockPrefab = Instantiate(prefabEffectBlock, position, Quaternion.identity);
            EffectBlock effectBlock = effectBlockPrefab.GetComponent<EffectBlock>();

            // set effect
            if (randomProbability < standardProbability + bonusProbability + freezeProbability)
            {
                effectBlock.Effect = EffectName.Freezer;
            }
            else
            {
                effectBlock.Effect = EffectName.Speedup;
            }
        }
    }

    #endregion
}
