using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoSetter : MonoBehaviour
{
    [SerializeField,Header("読み込み先の設定")] string folderName = "Screenshots";
    private string path = "";
    [SerializeField] private List<Image> photoObjs = new List<Image>();
    [SerializeField] private List<Sprite> spriteList = new List<Sprite>();

    private void Awake()
    {
        if (photoObjs.Count < AddressManager.Instance.photoAddress.Count)
        {
            Debug.LogError("必要分のイメージオブジェクトが足りません");
        }

        for (int i = 0; i < AddressManager.Instance.photoAddress.Count; i++)
        {
            path = Application.dataPath + "/" + folderName + "/" + AddressManager.Instance.photoAddress[i];

            byte[] bytes = File.ReadAllBytes(path);

            Texture2D texture = new Texture2D(2,2);

            texture.LoadImage(bytes);

            Rect rect = new Rect(0f, 0f, texture.width, texture.height);

            Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);

            spriteList.Add(sprite);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AddressManager.Instance.photoAddress.Count; i++)
        {
            photoObjs[i].sprite = spriteList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
