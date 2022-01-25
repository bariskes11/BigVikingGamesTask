using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCommands  : MonoBehaviour, IInventoryCommand
{
    #region Fields
    CommandList commands = new CommandList();
    #endregion
    #region Public Methods
    public void ReturnPreviousItem()
    {
        commands.Undo();
    }
    public void SelectedItem(IInventoryItem panelinfo)
    {
        commands.Execute(new SelectCommand(panelinfo));
    }

    #endregion

}
