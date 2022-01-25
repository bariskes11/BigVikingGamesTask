using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///  sets Selected inventory item values
/// </summary>
public class InventoryInfoPanel : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    Image itemImage;
    [SerializeField]
    new TextMeshProUGUI name;
    [SerializeField]
    TextMeshProUGUI description;
    [SerializeField]
    TextMeshProUGUI stats;
    #endregion
    #region Unity Methods
    private void Start()
    {
        // Listens for Selected Event
        EventManager.OnItemSelected.AddListener(SetSelectedValues);
    }
    #endregion
    #region Private Methods
    // sets All Items in InventoryItem
    void SetSelectedValues(IInventoryItem item)
    {

        this.itemImage.sprite = item.Icon.sprite;
        this.name.text = item.Name.text;
        this.description.text = item.Description;
        this.stats.text = item.Stat.ToString();

    }
    #endregion


}
