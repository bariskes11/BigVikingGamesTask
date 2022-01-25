using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Basic Animation Controller requires Animator to use
///  
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimController : MonoBehaviour
{
    
    #region Fields
    Animator anim;
    #endregion

    #region Unity Methods
    private void Start()
    {
        //fired on item selected
        EventManager.OnItemSelected.AddListener(SelectedItem);
        this.anim = this.GetComponent<Animator>();
    }
    #endregion
    #region Private Methods
    void SelectedItem(IInventoryItem inventoryItem)
    {
        StartCoroutine(AnimationCoroutine());
    }
    #endregion
    #region Coroutines
    /// <summary>
    /// basic coroutine to start animation
    /// </summary>
    /// <returns></returns>
    IEnumerator AnimationCoroutine()
    {
        anim.SetBool(PublicAnimEnums.EnUIAnimParameters.Selected.ToString(), false);
        yield return new WaitForSeconds(0.0001F);// very small value to timeout param change
        anim.SetBool(PublicAnimEnums.EnUIAnimParameters.Selected.ToString(), true);

    }

    #endregion

}
