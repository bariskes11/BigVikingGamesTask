using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// interface for possible inventory commands
/// </summary>
public interface IInventoryCommand 
{
    public void SelectedItem(IInventoryItem itemInfo);
    public void ReturnPreviousItem();
}
