using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject prefabPaddle;
    [SerializeField] GameObject prefabBlock;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(prefabPaddle);

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
                Instantiate(prefabBlock, currPosition, Quaternion.identity);
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

    #endregion
}
