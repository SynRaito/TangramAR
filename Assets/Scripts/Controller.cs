using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private GameObject Selected;
    public bool isFree;
    private void Start()
    {
        Selected = this.gameObject;
    }

    //Son dokunulan parçanın seçilmesi
    public void Select(GameObject slc)
    {

        UnSelect();
        Selected = slc;
        Selected.tag = "Selected";
    }

    void UnSelect()
    {
        if (Selected.tag != "Untagged")
        Selected.tag = "Untagged";
    }

    

}
