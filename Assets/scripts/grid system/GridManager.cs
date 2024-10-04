using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 10;  // Grid'in geniþliði
    public int gridHeight = 10; // Grid'in yüksekliði
    public float tileSize = 1f; // Her karenin boyutu
    public GameObject tilePrefab;  // Hücreler için kullanýlacak prefab (örn. boþ tarla)

    // Grid verisi, her hücredeki durumlarý saklayacak
    private int[,] gridData;

    void Start()
    {
        // Grid verisini baþlat
        gridData = new int[gridWidth, gridHeight];

        // Baþlangýçta verileri doldur (örneðin tüm hücreler 0 deðeriyle boþ)
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                gridData[x, y] = 0; // 0 = boþ, 1 = ekili alan, vs.
            }
        }

        // Sadece baþlangýçta görünür hücreler için görsel nesneleri oluþtur
        GenerateGridVisual();
    }

    // Grid'in sadece görsel kýsmýný oluþtur, veriler dizide saklanýyor
    void GenerateGridVisual()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * tileSize, 0, y * tileSize);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.name = $"Tile_{x}_{y}";
            }
        }
    }

    // Grid'de belirtilen hücre boþ mu?
    public bool IsCellEmpty(int x, int y)
    {
        return gridData[x, y] == 0;
    }

    // Hücrenin durumunu güncelle
    public void SetCell(int x, int y, int value)
    {
        gridData[x, y] = value;
    }

    // Hücrenin pozisyonunu hesapla
    public Vector3 GetCellPosition(int x, int y)
    {
        return new Vector3(x * tileSize, 0, y * tileSize);
    }
}