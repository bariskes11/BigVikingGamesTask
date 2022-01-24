using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  InfoPanel interface
/// </summary>
public interface IInfoPanel
{
    public Image ItemImage { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stat { get; set; }
    public void GetSelected(IInfoPanel obj);

}
