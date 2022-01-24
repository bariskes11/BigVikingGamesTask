using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="InventoryItem",menuName ="Assets/CreateInventoryItem")]
public abstract class ScriptableInventoryItem<T> : ScriptableObject
{
    private readonly List<IGameEventListen<T>> events = new List<IGameEventListen<T>>();
    

}
