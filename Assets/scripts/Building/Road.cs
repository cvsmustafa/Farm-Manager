using UnityEngine;

public class Road : Building
{
    private GameObject prefab;

    // Yapýcý metodda prefab'ý alýyoruz
    public Road(GameObject roadPrefab)
    {
        prefab = roadPrefab;
        Name = "Road";
    }

    public override void Build(Vector3 position)
    {
        base.Build(position);
        // Prefab'ý pozisyona instantiate ediyoruz
        GameObject.Instantiate(prefab, position, Quaternion.identity);
        Debug.Log("Road is being built at " + position);
    }
}
