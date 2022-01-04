using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class Screenshot : MonoBehaviour
{

    //ScreenShot Alma
    public Text txt;

    public void TakeShot()
    {
        StartCoroutine(Shooter());
    }

    IEnumerator Shooter()
    {

        yield return new WaitForEndOfFrame();

        txt.text = "Saving...";

        //Dosya isimleri ve lokasyonlarının oluşturulması || /storage/emulated/0/DCIM/Screenshots 'a kaydediliyor

        string FileName = "ScreenShot-" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second + ".png";

        string DefaultPath = Application.persistentDataPath + "/" + FileName;
        string FolderPath = "/storage/emulated/0/DCIM/Screenshots";
        string TargetPath = FolderPath + "/" + FileName;

        //Yoksa klasörün oluşturulması

            if (!System.IO.Directory.Exists(FolderPath))
            {
                System.IO.Directory.CreateDirectory(FolderPath);
            }

        //Ekran görüntüsü alınıyor
        ScreenCapture.CaptureScreenshot(FileName);

        yield return new WaitForSeconds(1);

        //Geçici dosyalardan DCIM'e taşınıyor || External Permission gerektiriyor
        System.IO.File.Move(DefaultPath, TargetPath);
        txt.text = "Saved!";

        yield return new WaitForSeconds(1);

        txt.text = "";

        //Galeriyi yenileme

        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_MOUNTED", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + TargetPath) });
        objActivity.Call("sendBroadcast", objIntent);
    }

}