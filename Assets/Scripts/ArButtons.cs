using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArButtons : MonoBehaviour
{

    //AR modunda oluşturulan şeklin boyutu ve yönünü ayarlama

    public GameObject Placement;
    
    public void RotateRight()
    {
        Placement.transform.GetChild(0).Rotate(0, 45, 0);
    }

    public void RotateLeft()
    {
        Placement.transform.GetChild(0).Rotate(0, -45, 0);
    }

    public void ScaleUp()
    {
        if(Placement.transform.localScale.x <= 0.75F)
        Placement.transform.localScale += new Vector3(0.025F, 0.025F, 0.025F);
    }

    public void ScaleDown()
    {
        if (Placement.transform.localScale.x >= 0.15F)
            Placement.transform.localScale -= new Vector3(0.025F, 0.025F, 0.025F);
    }
}
