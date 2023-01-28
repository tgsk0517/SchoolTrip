using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Screenshot : MonoBehaviour
{
    [SerializeField,Header("保存先の設定")] string folderName = "Screenshots";
    private bool isCreatingScreenShot = false;
    private string path = "";

    void Start()
    {
        path = Application.dataPath + "/" + folderName + "/";
    }

    public void PrintScreen()
    {
        StartCoroutine("PrintScreenInternal");
    }

    private IEnumerator PrintScreenInternal()
    {
        if (isCreatingScreenShot)
        {
            yield break;
        }
        isCreatingScreenShot = true;
        yield return null;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string date = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
        string fileName = path + date + ".png";
        AddressManager.Instance.photoAddress.Add(date + ".png");
        ScreenCapture.CaptureScreenshot(fileName);
        yield return new WaitUntil(() => File.Exists(fileName));
        isCreatingScreenShot = false;
    }
}
