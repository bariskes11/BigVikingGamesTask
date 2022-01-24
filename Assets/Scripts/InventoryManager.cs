using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Unity Fields
    //public InventoryInfoPanel InfoPanel;
    [SerializeField]
    IInfoPanel infoPanel;
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


    [Serializable]
    private class InventoryItemDatas
    {
        public InventoryItemData[] ItemDatas;
    }

    private InventoryItemData[] ItemDatas;

    private List<InventoryItem> Items;

    void Start()
    {
        // Clear existing items already in the list.
         var items = container.GetComponentsInChildren<InventoryItem>();
        foreach (InventoryItem item in items) {
            item.gameObject.transform.SetParent(null);
        }
        ItemDatas = GenerateItemDatas(this.itemJson, ItemGenerateScale);
        // Instantiate items in the Scroll View.
        Items = new List<InventoryItem>();
        foreach (InventoryItemData itemData in ItemDatas) {
            var newItem = GameObject.Instantiate<InventoryItem>(this.inventoryItemPrefab);
            newItem.Icon.sprite = icons[itemData.IconIndex];
            newItem.Name.text = itemData.Name;
            newItem.transform.SetParent(container.transform);
            newItem.Button.onClick.AddListener(() => { InventoryItemOnClick(newItem, itemData); });
            Items.Add(newItem);       
        }

        // Select the first item.
        InventoryItemOnClick(Items[0], ItemDatas[0]);
    }

    /// <summary>
    /// Generates an item list.
    /// </summary>
    /// <param name="json">JSON to generate items from. JSON must be an array of InventoryItemData.</param>
    /// <param name="scale">Concats additional copies of the array parsed from json.</param>
    /// <returns>An array of InventoryItemData</returns>
    private InventoryItemData[] GenerateItemDatas(string json, int scale) 
    {
        var itemDatas = JsonUtility.FromJson<InventoryItemDatas>(json).ItemDatas;
        var finalItemDatas = new InventoryItemData[itemDatas.Length * scale];
        for (var i = 0; i < itemDatas.Length; i++) {
            for (var j = 0; j < scale; j++) {
                finalItemDatas[i + j*itemDatas.Length] = itemDatas[i];
            }
        }

        return finalItemDatas;
    }

    private void InventoryItemOnClick(InventoryItem itemClicked, InventoryItemData itemData) 
    {
        foreach (var item in Items) {
            item.Background.color = Color.white;
        }
        itemClicked.Background.color = Color.red;
    }
}
