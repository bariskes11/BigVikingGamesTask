
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// 
///  Main Game object Creating Pool  Requires Pool Dictionary
///  Creates and Caches all game objects when game started
/// </summary>
[RequireComponent(typeof(PoolDictionary))]
public class CreateGameObjects : MonoBehaviour
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
    void Awake()
    {
        StartPooling();
    }

    public void StartPooling()
    {
        
        poolDic = GetComponent<PoolDictionary>();
        poolDic.ResetPool();
        poolDic.SetPool(gameObjectList, parent);
    }
    public GameObject CreateGameObject(string Objname, Vector3 pos, Transform parent)
    {
        return poolDic.SpawnFromPool(Objname, pos, parent);
    }
    public GameObject InstantiateObject(string TagName, Vector3 pos)
    {
        Pool item = gameObjectList.Where(x => x.Name == TagName).FirstOrDefault();
        if (item != null)
        {
            return Instantiate(item.Prefab, pos, Quaternion.identity);
        }
        return null;

    }




}
