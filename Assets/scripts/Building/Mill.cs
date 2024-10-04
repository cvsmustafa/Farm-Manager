using UnityEngine;

public class Mill : Building
{
    public Mill()
    {
        Name = "Mill";
    }

    public override void Build(Vector3 position)
    {
        base.Build(position);
        Debug.Log("Mill is being built...");
    }
}