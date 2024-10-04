using UnityEngine;

public abstract class Building
{
    public string Name { get; protected set; }

    public virtual void Build(Vector3 position)
    {
        // Her yapýnýn inþa iþlemi burada olur.
        Debug.Log($"Building {Name} at {position}");
    }
}
