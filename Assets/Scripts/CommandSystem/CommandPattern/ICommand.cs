using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main interface for all Commands
public interface ICommand 
{
    void Execute();
    void Undo();
}
