using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : ICommand
{
    private IInventoryItem inventoryItem;
    

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
   
