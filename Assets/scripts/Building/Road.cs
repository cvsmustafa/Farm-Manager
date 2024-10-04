using UnityEngine;

public class Road : Building
{
    private GameObject prefab;

    // Yap�c� metodda prefab'� al�yoruz
    public Road(GameObject roadPrefab)
    {
        prefab = roadPrefab;
        Name = "Road";
    }

    public override void Build(Vector3 position)
    {
        base.Build(position);
        // Prefab'� pozisyona instantiate ediyoruz
        GameObject.Instantiate(prefab, position, Quaternion.identity);
        Debug.Log("Road is being built at " + position);
    }
}
