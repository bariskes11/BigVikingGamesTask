using UnityEngine;
using System.Collections;


/// <summary>
/// Main  class  to create game object from pool
/// Keeps all pooledGameObjects Size can be Changed based on need
/// Name can be blank  if its blank creates with Prefabs name 
/// </summary>
[System.Serializable]
public class Pool
{
    public string Name;
    public GameObject Prefab;
    public int Size;
}

