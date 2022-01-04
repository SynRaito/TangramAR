using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ArControl : MonoBehaviour
{

    //Ar Moduna Geçiş

    public GameObject MainCamera;
    public GameObject ArKit;
    public GameObject BackGround;
    public GameObject UIBttn;
    public GameObject ARBttn;
    public GameObject Pieces;
    public GameObject Placement;
    private GameObject clone;
    private UnityEngine.Vector3 averageVector;

    public void ArMode()
    {

        //Ar Moduna Geçiş

        if (MainCamera.activeSelf)
        {

            //Componentleri düzenleme

            GameObject.Find("RandomShape").GetComponent<RandomShape>().MakeFree();
            MainCamera.SetActive(false);
            ArKit.SetActive(true);
            ARBttn.SetActive(true);
            UIBttn.SetActive(false);
            BackGround.SetActive(false);


            //Tangram parçalarının koordinatları hesaplanarak orta noktalarına parent amaçlı obje oluşturma

            averageVector = new UnityEngine.Vector3(0, 0, 0);

            for (int i = 0; i < Pieces.transform.childCount; i++)
            {
                averageVector.x += Pieces.transform.GetChild(i).transform.position.x;
                averageVector.y += Pieces.transform.GetChild(i).transform.position.y;
                averageVector.z += Pieces.transform.GetChild(i).transform.position.z;
            }

            //Parentın altına child olarak atama

            clone = new GameObject("Clone");

            clone.transform.position = new UnityEngine.Vector3(averageVector.x / Pieces.transform.childCount, averageVector.y / Pieces.transform.childCount, averageVector.z / Pieces.transform.childCount    );

            for (int i = 0; i < Pieces.transform.childCount; i++)
            {

                Instantiate(Pieces.transform.GetChild(i).gameObject, Pieces.transform.GetChild(i).transform.position, Pieces.transform.GetChild(i).transform.rotation, clone.transform).transform.GetChild(0).GetComponent<Renderer>().material.color = Pieces.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color;
                
            }

            clone.transform.localScale = new UnityEngine.Vector3(0.1F, 0.1F, 0.1F);
            clone.transform.position = Placement.transform.position;
            clone.transform.parent = Placement.transform;


            Pieces.SetActive(false);


        }
        else
        {

            //Ar Modundan Çıkış
            //Componentleri düzenleme

            Pieces.transform.parent = null; 
            MainCamera.SetActive(true);
            ArKit.SetActive(false);
            UIBttn.SetActive(true);
            ARBttn.SetActive(false);
            BackGround.SetActive(true);
            Pieces.SetActive(true);
            Destroy(clone);
        }
            

    }
}
