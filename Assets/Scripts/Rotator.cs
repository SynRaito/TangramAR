using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Rotate Butonu 
    private GameObject obje;
    public void Rotate()
    {
        obje = GameObject.FindGameObjectWithTag("Selected");
        
        //Simetrik olanlar ile olmayanların açılarının hesaplanması

        switch(obje.name){
            
            case "Kare":
                if (obje.transform.rotation.eulerAngles.y == 0)
                    obje.transform.Rotate(Vector3.up, 45, Space.World);
                else
                    obje.transform.Rotate(Vector3.down, 45, Space.World);
                break;
            
            case "Paralel":

                obje.transform.Rotate(Vector3.up, 45, Space.World);
                if (obje.transform.rotation.eulerAngles.y > 150)
                    obje.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;

            default:
                obje.transform.Rotate(Vector3.up, 45, Space.World);
                break;

        }
    }

}
