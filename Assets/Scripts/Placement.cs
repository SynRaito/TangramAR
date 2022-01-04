using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Placement : MonoBehaviour
{

    //AR Script
    
    private ARRaycastManager rayMan;
    //Yapılan şeklin kopyası (Yok edilecek)
    private GameObject point;
    public ARSessionOrigin origin;

    private void Start()
    {
        rayMan = origin.GetComponent<ARRaycastManager>();
    }

    private void Update()
    {

        //RayCast Hit
        if (transform.childCount == 1)
            point = transform.GetChild(0).gameObject;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayMan.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!point.activeInHierarchy)
                point.SetActive(true);
        }
    }
}
