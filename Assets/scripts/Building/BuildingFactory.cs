using UnityEngine;

public class BuildingFactory : MonoBehaviour
{
    public GameObject fieldPrefab;  // Tarla prefab'�
    public GameObject roadPrefab;   // Yol prefab'�
    public GameObject fencePrefab;
    //public GameObject millPrefab;   // Yel de�irmeni prefab'�

    public GameObject fieldPrefabpreview;  // Tarla prefab'�
    public GameObject roadPrefabpreview;   // Yol prefab'�
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
                return fieldPrefab; // Tarla prefab'�n� d�nd�r
            case BuildingType.Road:
                return roadPrefab;  // Yol prefab'�n� d�nd�r
            case BuildingType.Fence:
                return fencePrefab;

            //case BuildingType.Mill:                    
            //  return millPrefab;  // Yel de�irmeni prefab'�n� d�nd�r
            default:
                throw new System.ArgumentException("Invalid building type");
        }
    }
    //------------------------------�nizleme------------------------------------------
    public GameObject CreateBuildingpreview(BuildingTypepreview typepreview)
    {
        switch (typepreview)
        {
            case BuildingTypepreview.Fieldpreview:
                return fieldPrefabpreview; // Tarla prefab'�n� d�nd�r
            case BuildingTypepreview.Roadpreview:
                return roadPrefabpreview;  // Yol prefab'�n� d�nd�r
            case BuildingTypepreview.Fencepreview:
                return fencePrefabpreview;

            //case BuildingType.Mill:                    
            //  return millPrefab;  // Yel de�irmeni prefab'�n� d�nd�r
            default:
                throw new System.ArgumentException("Invalid building preview type");
        }
    }
}