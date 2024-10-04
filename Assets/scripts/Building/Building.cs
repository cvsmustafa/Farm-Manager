using UnityEngine;

public abstract class Building
{
    public string Name { get; protected set; }

    public virtual void Build(Vector3 position)
    {
        // Her yap�n�n in�a i�lemi burada olur.
        Debug.Log($"Building {Name} at {position}");
    }
}
