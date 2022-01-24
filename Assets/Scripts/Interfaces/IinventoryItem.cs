using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IInventoryItem 
{
    public Image Background { get; set; }
    public Image Icon { get; set; }
    public TextMeshProUGUI Name { get; set; }
    public Button Button { get; set; }

    
}
