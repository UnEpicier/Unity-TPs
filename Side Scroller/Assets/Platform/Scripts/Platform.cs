using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Platform : MonoBehaviour
{
    [SerializeField]
    private int _size = 3;

    public int Size
    {
        get { return _size; }
        set {
            _size = value;
            limitX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - (tilemap.cellSize.x * _size);
            initWithSize();
        }
    }

    [SerializeField]
    private TileBase[] tiles;

    private Tilemap tilemap;
    private Vector3Int[] positions;
    private TileBase[] finals;

    private float limitX;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();

        initWithSize();
        limitX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - (tilemap.cellSize.x * _size);
    }

    private void Update()
    {
        transform.Translate(new Vector3(-5f * Time.deltaTime, 0, 0));

        if (transform.position.x <= limitX)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void initWithSize()
    {
        if (_size < 2)
        {
            Debug.LogError("Can't generate a plateform with such a small width.");
            return;
        }

        positions = new Vector3Int[_size];
        finals = new TileBase[_size];

        // Prepare tiles
        finals[0] = tiles[0];
        positions[0] = new Vector3Int(0, 0, 0);

        for (int i = 1; i < _size - 1; i++)
        {
            finals[i] = tiles[1];
            positions[i] = new Vector3Int(i, 0, 0);
        }

        positions[positions.Length - 1] = new Vector3Int(_size - 1, 0, 0);
        finals[finals.Length - 1] = tiles[2];

        tilemap.SetTiles(positions, finals);
    }
}
