using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
///  All Events are stored in this static class 
///  can add diferent events to invoke or addlistener
/// 
/// </summary>
public static class EventManager 
{
    public static ItemSelectedEvent OnItemSelected = new ItemSelectedEvent();
}
