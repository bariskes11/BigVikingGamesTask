using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : ICommand
{
    private IInfoPanel currentPanel;

    public SelectCommand(IInfoPanel currentpanel)
    {
        this.currentPanel = currentpanel;
    }

    public void Execute()
    {
        
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}
   
