using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Inventory  Select Command inherited from ICommand
/// </summary>
public class SelectCommand : ICommand
{
    private IInventoryItem inventoryItem;
    /// <summary>
    /// Constructor for Select Command
    /// </summary>
    /// <param name="inventoryItem"></param>
    public SelectCommand(IInventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
    }
    public void Execute()
    {
    }

    public void Undo()
    {
        //Calls Previous Selected Event
        EventManager.OnItemSelected.Invoke(this.inventoryItem);
    }
}
   
