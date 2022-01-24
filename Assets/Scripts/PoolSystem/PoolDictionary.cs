using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Keeps All Pooled items in this class spawns object from pool when needed
/// </summary>
public class PoolDictionary : MonoBehaviour
{
    #region Properties
    private Dictionary<string, Queue<GameObject>> mainPoolDictionary;
    public Dictionary<string, Queue<GameObject>> MainPoolDictionary
    {
        get => this.mainPoolDictionary;
        set => this.mainPoolDictionary = value;
    }
    #endregion
    #region Fields
    private List<Pool> pool;
    #endregion
    #region Public Methods
    /// <summary>
    /// Resets Pool
    /// </summary>
    public void ResetPool()
    {
        this.pool = new List<Pool>();
    }
    /// <summary>
    /// Call Object from pool
    /// </summary>
    /// <param name="name">Name of Prefab</param>
    /// <param name="position">Position</param>
    /// <param name="parent">Parent in editor</param>
    /// <returns></returns>
    public GameObject SpawnFromPool(string name, Vector3 position, Transform parent)
    {
        if (!MainPoolDictionary.ContainsKey(name))
        {
            Debug.LogError("Object Name not Found:" + name);
            return null;
        }
        // Dequeue from pool dictionary
        GameObject spawnObj = this.mainPoolDictionary[name].Dequeue();
        //makes selected gameobject active
        activateAllChildren(spawnObj);
        if (parent != null)
        {
            spawnObj.transform.SetParent(parent);
        }
        spawnObj.transform.position = position;
        spawnObj.transform.rotation = Quaternion.identity;
        this.mainPoolDictionary[name].Enqueue(spawnObj);
        return spawnObj;
    }
    #endregion


    // starts objectpool
    public void SetPool(List<Pool> pool, Transform parent)
    {
        this.pool = pool;
        MainPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool item in this.pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < item.Size; i++)
            {
                GameObject gmObj = Instantiate(item.Prefab);
                gmObj.SetActive(false);
                if (item.Name == String.Empty) // if there is no name set name to prefabs name
                {
                    item.Name = item.Prefab.name;
                }
                if (parent != null)
                {
                    gmObj.transform.SetParent(parent);
                }
                objectPool.Enqueue(gmObj);

            }
            // add pooled object to dictionary
            MainPoolDictionary.Add(item.Name, objectPool);
        }
    }
    /// <summary>
    ///  Activate object with all child transforms
    /// </summary>
    /// <param name="gmobj">Game Object</param>
    private void activateAllChildren(GameObject gmobj)
    {
        gmobj.SetActive(true);
        for (int j = 0; j < gmobj.transform.childCount; j++)
        {
            gmobj.transform.GetChild(j).gameObject.SetActive(true);
        }

    }





}
