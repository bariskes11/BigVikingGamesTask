using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListen<T> 
{
    void EventRaised(T item);
}
