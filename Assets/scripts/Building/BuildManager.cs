using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GridManager gridManager;
    public BuildingFactory buildingFactory;

    private BuildingFactory.BuildingType? selectedBuildingType = null;
    //private GameObject previewObject = null;
    private bool isVertical = false;

    void Update()
    {
        HandleBuildingSelection();
        HandleBuildingPlacement();
        HandleEscapeKey();
    }

    // Sol fare tuþuna basýldýðýnda yapý yerleþtirme
    void HandleBuildingPlacement()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuildingType != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject hitTile = hit.collider.gameObject;
                if (hitTile.CompareTag("Tile"))
                {
                    Vector3 hitPosition = hit.point;
                    int x = Mathf.FloorToInt(hitPosition.x / gridManager.tileSize);
                    int y = Mathf.FloorToInt(hitPosition.z / gridManager.tileSize);

                    if (x >= 0 && x < gridManager.gridWidth && y >= 0 && y < gridManager.gridHeight && gridManager.IsCellEmpty(x, y))
                    {
                        GameObject buildingObj = buildingFactory.CreateBuilding(selectedBuildingType.Value);
                        if (buildingObj != null)
                        {
                            Vector3 buildPosition = gridManager.GetCellPosition(x, y);
                            Instantiate(buildingObj, buildPosition, Quaternion.identity);
                            gridManager.SetCell(x, y, 1); // Hücreyi dolu olarak iþaretle
                        }
                    }
                    else
                    {
                        Debug.Log("Bu hücre dolu!");
                    }
                }
            }
        }
    }

    // Yapý seçimi için klavye kontrolleri
    void HandleBuildingSelection()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            selectedBuildingType = BuildingFactory.BuildingType.Field;
            Debug.Log("Tarla seçildi.");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            selectedBuildingType = BuildingFactory.BuildingType.Road;
            Debug.Log("Yol seçildi.");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            selectedBuildingType = BuildingFactory.BuildingType.Fence;
            Debug.Log("Çit seçildi.");
        }

        if (Input.GetKeyDown(KeyCode.V) && selectedBuildingType == BuildingFactory.BuildingType.Fence)
        {
            isVertical = !isVertical;
            Debug.Log(isVertical ? "Dikey çit seçildi." : "Yatay çit seçildi.");
        }
    }

    // ESC ile inþa modundan çýkma
    void HandleEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedBuildingType = null;
            Debug.Log("Ýnþa modundan çýkýldý.");
        }
    }

    // Yapý seçme fonksiyonlarý
    public void SelectField()
    {
        selectedBuildingType = BuildingFactory.BuildingType.Field;
        Debug.Log("Tarla seçildi.");
    }

    public void SelectRoad()
    {
        selectedBuildingType = BuildingFactory.BuildingType.Road;
        Debug.Log("Yol seçildi.");
    }

    public void SelectFence()
    {
        selectedBuildingType = BuildingFactory.BuildingType.Fence;
        Debug.Log("Çit seçildi.");
    }
}
