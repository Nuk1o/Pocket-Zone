using UnityEngine;

public interface IItem
{
    string Name { get; }
    Sprite UIIcon { get; }
    
    int CountItems { get; }
}
