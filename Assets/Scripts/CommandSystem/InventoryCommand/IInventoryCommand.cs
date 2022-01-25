using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryCommand 
{
    public void SelectedItem(IInventoryItem itemInfo);
    public void ReturnPreviousItem();
}
