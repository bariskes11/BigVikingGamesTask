using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    InventoryItem inventoryItemPrefab;
    [SerializeField]
    GameObject container;
    [Tooltip(tooltip: "Loads the list using this format.")]
    [Multiline]
    [SerializeField]
    string itemJson;
    [Tooltip(tooltip: "This is used in generating the items list. The number of additional copies to concat the list parsed from ItemJson.")]
    [SerializeField]
    int ItemGenerateScale = 10;
    [SerializeField]
    [Tooltip(tooltip: "Icons referenced by ItemData.IconIndex when instantiating new items.")]
    Sprite[] icons;
    #endregion
    #region Fields
    List<InventoryItemData> itemDatas = new List<InventoryItemData>();
    List<InventoryItem> items;
    #endregion
    #region Unity Methods
    void Start()
    {
        this.ClearItems();
        this.itemDatas = GenerateItemDatas(this.itemJson);
        
        // Select the first item.
        InventoryItemOnClick(this.items[0], this.itemDatas[0]);
    }
    #endregion

    #region Private Methods
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
        this.items = new List<InventoryItem>();
        foreach (InventoryItemData itemData in this.itemDatas)
        {
            var newItem = GameObject.Instantiate<InventoryItem>(this.inventoryItemPrefab);
            newItem.Icon.sprite = icons[itemData.IconIndex];
            newItem.Name.text = itemData.Name;
            newItem.transform.SetParent(container.transform);
            newItem.Button.onClick.AddListener(() => { InventoryItemOnClick(newItem, itemData); });
            this.items.Add(newItem);
        }

    }

    /// <summary>
    /// Returns Array From Json
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    List<InventoryItemData> GenerateItemDatas(string json)
    {
        return JsonUtility.FromJson<InventoryItemDatas>(json).ItemDatas.ToList();
    }

     void InventoryItemOnClick(InventoryItem itemClicked, InventoryItemData itemData)
    {

        foreach (var item in items)
        {
            item.Background.color = Color.white;
        }
        itemClicked.Background.color = Color.red;
    }
    #endregion

}
