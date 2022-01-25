using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IInventoryItem
{
    #region Unity Fields
    [SerializeField]
    Image backGround;
    [SerializeField]
    Image icon;
    [SerializeField]
    new TextMeshProUGUI name;
    [SerializeField]
    Button button;
    #endregion
    #region Interface Properties
    public Image Background { get => backGround; set => backGround = value; }
    public Image Icon { get => icon; set => icon = value; }

    public TextMeshProUGUI Name { get => name; set => name = value; }
    public Button Button { get => button; set => button = value; }
    private string description;
    public string Description { get => this.description; set => this.description=value; }
    private int stat;
    public int Stat { get => this.stat; set => this.stat = value; }
    #endregion


}
