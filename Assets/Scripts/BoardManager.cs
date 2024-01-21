using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private Vector2Int boardSize;
    [SerializeField] private float horizontalTileSize = 1.73f;
    [SerializeField] private float verticalTileSize = 1.5f;

    private ulong[] _board;

    private void Start()
    {
        int ulongCount = (boardSize.x * boardSize.y + 63) / 64;

        _board = new ulong[ulongCount];

        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int row = 0; row < boardSize.y; row++)
            for (int col = 0; col < boardSize.x; col++)
            {
                Vector3 pos;
                if (row % 2 == 0)
                {
                    pos = new Vector3(row * horizontalTileSize / 2, 0, (col * verticalTileSize * 2f));
                }
                else
                {
                    pos = new Vector3(row * horizontalTileSize / 2, 0, (col * verticalTileSize * 2f) + verticalTileSize);
                }
                GameObject tile = Instantiate(hexPrefab, pos, Quaternion.identity);
                tile.name = $"{tile.name}_{row}_{col}";
            }

    }
}
