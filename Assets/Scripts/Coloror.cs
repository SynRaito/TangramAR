using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloror : MonoBehaviour
{
    //RGB UI bileşenleri

    private GameObject obje;
    public RawImage rgb;
    Renderer rend;
    public Slider Rslide;
    public Slider Gslide;
    public Slider Bslide;

    private void Update()
    {

        //UI'daki image'i anlık renklendirme

        rgb.color = new Color(Rslide.value, Gslide.value, Bslide.value);
        obje = GameObject.FindGameObjectWithTag("Selected");
    }
    public void Color()
    {
        //Renklendirme butonuyla son dokunulan parçayı renklendirme

        rend = obje.GetComponentInChildren<Renderer>();

        rend.material.color = new Color(Rslide.value, Gslide.value, Bslide.value);
    }
}
