using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList
{
    #region Fields
    private const int MAXCOMMAND = 100;
    private Stack<ICommand> commandList = new Stack<ICommand>();
    #endregion
    #region Public Methods

    public void Execute(ICommand command)
    {
        command.Execute();
        if (commandList.Count < MAXCOMMAND)
            commandList.Push(command);
    }

    public void Undo()
    {
        if (commandList.Count <= 0)
            return;
        commandList.Pop().Undo();
    }
    #endregion


}
