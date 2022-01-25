using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Image))]

public class AnimController : MonoBehaviour
{
    
    #region Fields
    Animator anim;
    Image currentImage;
    #endregion

    #region Unity Methods
    private void Start()
    {
        EventManager.OnItemSelected.AddListener(SelectedItem);
        this.anim = this.GetComponent<Animator>();
        this.currentImage = this.GetComponent<Image>();
    }
    #endregion
    #region Private Methods
    void SelectedItem(IInventoryItem inventoryItem)
    {
        StartCoroutine(AnimationCoroutine());
    }
    #endregion
    #region Coroutines
    IEnumerator AnimationCoroutine()
    {
        anim.SetBool(PublicAnimEnums.EnUIAnimParameters.Selected.ToString(), false);
        yield return new WaitForSeconds(0.0001F);// very small value to timeout param change
        anim.SetBool(PublicAnimEnums.EnUIAnimParameters.Selected.ToString(), true);



    }

    #endregion

}
