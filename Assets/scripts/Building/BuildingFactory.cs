using UnityEngine;

public class BuildingFactory : MonoBehaviour
{
    public GameObject fieldPrefab;  // Tarla prefab'ý
    public GameObject roadPrefab;   // Yol prefab'ý
    public GameObject fencePrefab;
    //public GameObject millPrefab;   // Yel deðirmeni prefab'ý

    public GameObject fieldPrefabpreview;  // Tarla prefab'ý
    public GameObject roadPrefabpreview;   // Yol prefab'ý
    public GameObject fencePrefabpreview;

    public enum BuildingType
    {
        Field,
        Road,
        Mill,
        Fence
    }
    public enum BuildingTypepreview
    {
        Fieldpreview,
        Roadpreview,
        Millpreview,
        Fencepreview
    }

    public GameObject CreateBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Field:
                return fieldPrefab; // Tarla prefab'ýný döndür
            case BuildingType.Road:
                return roadPrefab;  // Yol prefab'ýný döndür
            case BuildingType.Fence:
                return fencePrefab;

            //case BuildingType.Mill:                    
            //  return millPrefab;  // Yel deðirmeni prefab'ýný döndür
            default:
                throw new System.ArgumentException("Invalid building type");
        }
    }
    //------------------------------Önizleme------------------------------------------
    public GameObject CreateBuildingpreview(BuildingTypepreview typepreview)
    {
        switch (typepreview)
        {
            case BuildingTypepreview.Fieldpreview:
                return fieldPrefabpreview; // Tarla prefab'ýný döndür
            case BuildingTypepreview.Roadpreview:
                return roadPrefabpreview;  // Yol prefab'ýný döndür
            case BuildingTypepreview.Fencepreview:
                return fencePrefabpreview;

            //case BuildingType.Mill:                    
            //  return millPrefab;  // Yel deðirmeni prefab'ýný döndür
            default:
                throw new System.ArgumentException("Invalid building preview type");
        }
    }
}