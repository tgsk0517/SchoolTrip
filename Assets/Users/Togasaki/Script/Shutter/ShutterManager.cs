using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShutterManager : SingletonMonoBehaviour<ShutterManager>
{
    [SerializeField]
    private Image flashImage;

    [SerializeField,Header("シャッターの速さ")]
    private float speed = 1;

    [SerializeField]
    private Color subColor = new Color(0, 0, 0, 0.1f);

    private Color baseColor = new Color(1, 1, 1, 1);
    private WaitForSeconds wfs = new WaitForSeconds(0.02f);


    /// <summary>
    /// シャッターを切る
    /// </summary>
    public void ShutterOn(int studentNum,int other)
    {
        flashImage.color = baseColor;
        flashImage.enabled = true;
        AudioManager.Instance.PlaySE(SEName.shutter);

        ScoreManager.Instance.ScoreCalc(studentNum,other);

        StartCoroutine(ShutterEffect());
    }

    IEnumerator ShutterEffect()
    {
        while(flashImage.color.a > 0)
        {
            flashImage.color -= subColor * speed;

            yield return wfs;
        }
    }


}
