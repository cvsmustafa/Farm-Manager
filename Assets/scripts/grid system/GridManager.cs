using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 10;  // Grid'in geni�li�i
    public int gridHeight = 10; // Grid'in y�ksekli�i
    public float tileSize = 1f; // Her karenin boyutu
    public GameObject tilePrefab;  // H�creler i�in kullan�lacak prefab (�rn. bo� tarla)

    // Grid verisi, her h�credeki durumlar� saklayacak
    private int[,] gridData;

    void Start()
    {
        // Grid verisini ba�lat
        gridData = new int[gridWidth, gridHeight];

        // Ba�lang��ta verileri doldur (�rne�in t�m h�creler 0 de�eriyle bo�)
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                gridData[x, y] = 0; // 0 = bo�, 1 = ekili alan, vs.
            }
        }

        // Sadece ba�lang��ta g�r�n�r h�creler i�in g�rsel nesneleri olu�tur
        GenerateGridVisual();
    }

    // Grid'in sadece g�rsel k�sm�n� olu�tur, veriler dizide saklan�yor
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

    // Grid'de belirtilen h�cre bo� mu?
    public bool IsCellEmpty(int x, int y)
    {
        return gridData[x, y] == 0;
    }

    // H�crenin durumunu g�ncelle
    public void SetCell(int x, int y, int value)
    {
        gridData[x, y] = value;
    }

    // H�crenin pozisyonunu hesapla
    public Vector3 GetCellPosition(int x, int y)
    {
        return new Vector3(x * tileSize, 0, y * tileSize);
    }
}