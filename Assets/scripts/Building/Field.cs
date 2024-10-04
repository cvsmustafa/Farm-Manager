using UnityEngine;

public class Field : Building
{
    private GameObject prefab;

    public Field(GameObject fieldPrefab)
    {
        prefab = fieldPrefab;
        Name = "Field";
    }

    public override void Build(Vector3 position)
    {
        base.Build(position);
        GameObject.Instantiate(prefab, position, Quaternion.identity);
        Debug.Log("Field is being built at " + position);
    }
}
