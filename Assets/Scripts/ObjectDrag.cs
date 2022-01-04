using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDrag : MonoBehaviour
{
    private int Cont;
    private AudioSource Sound;
    private GameObject contUnit;
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject target;

    //Parçaların hedef koordinatları ve açıları
    private Vector3 targetPositionAlt;
    private Vector3 targetPosition;
    private Quaternion targetRotationAlt;
    private Quaternion targetRotation;

    //Hata kaynaklı tolere edilebilecek sapma değerleri
    private float posTolerance= 0.5f;
    private float rotTolerance = 2.5f;
    private void Awake()
    {
        //Ses ve Seçilmelerin bağlı olduğu objeler
        Sound = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        contUnit = GameObject.Find("ControlUnit");

        //Rastgele Renklendirme
        this.gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }
    public void FindShape()
    {
        
        //Masada duran "Shape"i bul
        target = GameObject.FindGameObjectWithTag("Shape");

        //Transformun parentının ismine göre "Shape"in childı olan targetı bulma

        if(transform.parent.name == "UcgenBuyu" || transform.parent.name == "UcgenKucu")
        {
            targetPosition = target.transform.Find(transform.parent.name + "kPlane1").transform.position;
            targetPositionAlt = target.transform.Find(transform.parent.name + "kPlane2").transform.position;
            targetRotation = target.transform.Find(transform.parent.name + "kPlane1").transform.rotation;
            targetRotationAlt = target.transform.Find(transform.parent.name + "kPlane2").transform.rotation;
            Cont = 1;
        }
        else if (transform.parent.name == "UcgenBuyuk" || transform.parent.name == "UcgenKucuk")
        {
            targetPosition = target.transform.Find(transform.parent.name + "Plane1").transform.position;
            targetPositionAlt = target.transform.Find(transform.parent.name + "Plane2").transform.position;
            targetRotation = target.transform.Find(transform.parent.name + "Plane1").transform.rotation;
            targetRotationAlt = target.transform.Find(transform.parent.name + "Plane2").transform.rotation;
            Cont = 1;
        }
        else
        {
            targetPosition = target.transform.Find(transform.parent.name + "Plane").transform.position;
            targetRotation = target.transform.Find(transform.parent.name + "Plane").transform.rotation;
            Cont = 0;
        }

        
    }
    void OnMouseDown()
    {
        //Objelerin drag işlemleri
        if (!GameObject.Find("RandomShape").transform.GetComponent<RandomShape>().isFree)
            FindShape();
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        //Objelerin drag işlemleri
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.parent.position = curPosition;
    }

    private void OnMouseUp()
    {
        //Pozisyon Kontrolü 
        //Hedefe yeterince yakınsa hedefe konuma oturtma

        switch (Cont)
        {
            case 1:

                if (transform.position.x < targetPosition.x + posTolerance && transform.position.x > targetPosition.x - posTolerance && transform.position.z < targetPosition.z + posTolerance && transform.position.z > targetPosition.z - posTolerance && transform.parent.rotation.eulerAngles.y < targetRotation.eulerAngles.y + rotTolerance && transform.parent.rotation.eulerAngles.y > targetRotation.eulerAngles.y - rotTolerance)
                {
                    if (transform.parent.position != targetPosition)
                        Sound.Play(0);

                    transform.parent.position = targetPosition;
                }

                else if (transform.position.x < targetPositionAlt.x + posTolerance && transform.position.x > targetPositionAlt.x - posTolerance && transform.position.z < targetPositionAlt.z + posTolerance && transform.position.z > targetPositionAlt.z - posTolerance && transform.parent.rotation.eulerAngles.y < targetRotationAlt.eulerAngles.y + rotTolerance && transform.parent.rotation.eulerAngles.y > targetRotationAlt.eulerAngles.y - rotTolerance)
                    {
                        if (transform.parent.position != targetPositionAlt)
                            Sound.Play(0);

                        transform.parent.position = targetPositionAlt;
                    }
                break;

            case 0:
                if (transform.position.x < targetPosition.x + posTolerance && transform.position.x > targetPosition.x - posTolerance && transform.position.z < targetPosition.z + posTolerance && transform.position.z > targetPosition.z - posTolerance && transform.parent.rotation.eulerAngles.y < targetRotation.eulerAngles.y + rotTolerance && transform.parent.rotation.eulerAngles.y > targetRotation.eulerAngles.y - rotTolerance)
                {
                    if (transform.parent.position != targetPosition)
                        Sound.Play(0);

                    transform.parent.position = targetPosition;
                }
                break;
        }        

        //Seçilme işlemi

        contUnit.GetComponent<Controller>().Select(this.transform.parent.gameObject);




    }
}
