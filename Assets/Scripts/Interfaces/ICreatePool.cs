using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  main interface for pooling system.
/// </summary>
public interface ICreatePool
{
    public void StartPooling();
    public GameObject CreateGameObject(string Objname, Vector3 pos, Transform parent);
}
