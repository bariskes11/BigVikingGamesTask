
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
///  Main Game object Creating Pool  Requires Pool Dictionary
///  Creates and Caches all game objects when game started
/// </summary>
[RequireComponent(typeof(PoolDictionary))]
public class CreateGameObjects : MonoBehaviour,ICreatePool
{
    #region Unity Fields
    [SerializeField]
    Transform parent;
    [SerializeField]
    List<Pool> gameObjectList;
    #endregion
    #region Fields
    PoolDictionary poolDic;
    #endregion
    #region Properties
    public List<Pool> GameObjectList
    {
        get => this.gameObjectList;
    }
    #endregion
    #region Unity Methods
    void Awake()
    {
        StartPooling();
    }
    #endregion

    #region Interface Methods
    public void StartPooling()
    {
        poolDic = GetComponent<PoolDictionary>();
        poolDic.ResetPool();
        poolDic.SetPool(gameObjectList, parent);
    }
    /// <summary>
    /// Creates Gameobject from pool
    /// </summary>
    /// <param name="Objname">Name of Game object</param>
    /// <param name="pos">Gameobject Position</param>
    /// <param name="parent">Parent Game object </param>
    /// <returns></returns>
    public GameObject CreateGameObject(string Objname, Vector3 pos, Transform parent)
    {
        return poolDic.SpawnFromPool(Objname, pos, parent);
    }

    #endregion



}
