using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Platform : MonoBehaviour
{
    [SerializeField]
    private int width = 3;
    [SerializeField]
    private TileBase[] tiles;

    private Tilemap tilemap;
    private Vector3Int[] positions;
    private TileBase[] finals;

    private void Awake()
    {
        positions = new Vector3Int[width];
        finals = new TileBase[width];

        tilemap = GetComponent<Tilemap>();

        // Prepare tiles
        finals[0] = tiles[0];
        positions[0] = new Vector3Int(0, 0, 0);

        for(int i = 1; i < width; i++)
        {
            finals[i] = tiles[1];
            positions[i] = new Vector3Int(i, 0, 0);
        }

        positions[positions.Length - 1] = new Vector3Int(width - 1, 0, 0);
        finals[finals.Length - 1] = tiles[2];

        tilemap.SetTiles(positions, finals);
    }
}
