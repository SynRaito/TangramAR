using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomShape : MonoBehaviour
{
    //Rastgele "Shape" oluşturma

    public bool isFree=true;
    private static GameObject[] shapes;
    void Start()
    {
        //Resources'dan bütün prefabları çekme
        shapes = Resources.LoadAll<GameObject>("Shapes");

        GameObject obj = Instantiate(shapes[Random.Range(0,shapes.Length)]);

        obj.transform.position = new Vector3(0, 0, 0);
    }

    public void CreateRandom()
    {
        //Yeni bir shape oluşturma
        Destroy(GameObject.FindGameObjectWithTag("Shape"));
        GameObject obj = Instantiate(shapes[Random.Range(0, shapes.Length)]);
        isFree = false;
        obj.transform.position = new Vector3(0, 0, 0);
    }

    public void MakeFree()
    {
        //Shape'i kaldırma
        if(!isFree)
        Destroy(GameObject.FindGameObjectWithTag("Shape"));
        isFree = true;
    }   
}
