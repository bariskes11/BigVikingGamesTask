using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class InventoryManager : MonoBehaviour
{
    #region Unity Fields
    [Range(1, 5)]
    [Header("Load Data xx Times Based on value")]
    [SerializeField]
    int loadDataCount;
    [SerializeField]
    SpriteAtlas spriteAtlas;
    [SerializeField]
    GameObject container;
    [Tooltip(tooltip: "Loads the list using this format.")]
    [Multiline]
    [SerializeField]
    string itemJson;
    [Tooltip(tooltip: "This is used in generating the items list. The number of additional copies to concat the list parsed from ItemJson.")]
    [SerializeField]
    int itemGenerateScale = 10;
    [SerializeField]
    [Tooltip(tooltip: "Icons referenced by ItemData.IconIndex when instantiating new items.")]
    Sprite[] icons;
    #endregion
    #region Fields
    private const string ITEMNAME = "InventoryItem";
    List<InventoryItemData> itemDatas = new List<InventoryItemData>();
    List<IInventoryItem> items;
    IInventoryCommand inventoryCommands;
    ICreatePool createPool;
    #endregion
    #region Unity Methods
    void Start()
    {
        this.inventoryCommands=  this.GetComponent<IInventoryCommand>();
        if (this.inventoryCommands == null) { Debug.LogError("<color=red> there is no inventory command object!!</color>"); }
        //Gets First Pooled object from Interface
        this.GetPoolSystem();
        this.ClearItems();
        this.GenerateItemDatas(this.itemJson);
        this.FillContainer();
        this.InventoryItemOnClick(this.items[0], this.itemDatas[0]);
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Find First Pool system from scene
    /// </summary>
    void GetPoolSystem()
    {
        // gets PoolSystem from Scene using linq
        this.createPool = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<ICreatePool>().FirstOrDefault();
        if (createPool == null)
        {
            Debug.LogError($"<color=red>There is No GameobjectPooler in Scene </color>");
        }
    }
    /// <summary>
    ///  Clears all items
    /// </summary>
    void ClearItems()
    {
        // Clear existing items already in the list.
        var items = container.GetComponentsInChildren<InventoryItem>().ToList();
        //refactored to linq
        items.ForEach(x => x.gameObject.transform.SetParent(null));


    }
    void FillContainer()
    {
        // Instantiate items in the Scroll View.
        this.items = new List<IInventoryItem>();
        /// added to load data more than once when needed (to check performance behaviour)
        /// no needed in real development
        for (int i = 0; i < this.loadDataCount; i++)
        {
            foreach (InventoryItemData itemData in this.itemDatas)
            {
                if (createPool.CreateGameObject(ITEMNAME, Vector3.zero, this.container.transform).TryGetComponent<IInventoryItem>(out var newitem))
                {
                    AddItem(itemData, newitem);
                }
            }
        }
    }
    /// <summary>
    /// Sets inventory and adds to item list
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="newitem"></param>
    void AddItem(InventoryItemData itemData, IInventoryItem newitem)
    {
        newitem.Icon.sprite = spriteAtlas.GetSprite(icons[itemData.IconIndex].name);
        newitem.Name.text = itemData.Name;
        newitem.Description = itemData.Description;
        newitem.Stat = itemData.Stat;
        newitem.Button.onClick.AddListener(() => { InventoryItemOnClick(newitem, itemData); });
        this.items.Add(newitem);
    }

    /// <summary>
    /// sets Item Datas from json
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    void GenerateItemDatas(string json)
    {
        // sets main data source
        this.itemDatas = JsonUtility.FromJson<InventoryItemDatas>(json).ItemDatas.ToList();

        var itemDatas = JsonUtility.FromJson<InventoryItemDatas>(json).ItemDatas;
        var finalItemDatas = new InventoryItemData[itemDatas.Length * this.itemGenerateScale];
        for (var i = 0; i < itemDatas.Length; i++)
        {
            for (var j = 0; j < this.itemGenerateScale; j++)
            {
                finalItemDatas[i + j * itemDatas.Length] = itemDatas[i];
            }
        }

    }
    /// <summary>
    ///  sets clicked item color to red other ones to white
    /// </summary>
    /// <param name="itemClicked"></param>
    /// <param name="itemData"></param>
    void InventoryItemOnClick(IInventoryItem itemClicked, InventoryItemData itemData)
    {
        this.items.ForEach(x => x.Background.color = Color.white);
        itemClicked.Background.color = Color.red;
        /// Added To Command List
        this.inventoryCommands.SelectedItem(itemClicked);
        // Informed EventManager when Item Selected
        EventManager.OnItemSelected.Invoke(itemClicked);
    }
    #endregion

}
