using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoPanel : MonoBehaviour, IInfoPanel
{

    #region Interface Properties
    private Image itemImage;
    public Image ItemImage { get => this.itemImage; set => this.itemImage=value; }
    private new string name;
    public string Name { get => this.name; set => this.name=value; }
    private string description;
    public string Description { get => this.description; set => this.description=value; }
    private int stat;
    public int Stat { get => this.stat; set => this.stat=value; }
    #endregion
    #region Interface Methods
    public void GetSelected(IInfoPanel obj)
    {
        
    }
    #endregion

}
