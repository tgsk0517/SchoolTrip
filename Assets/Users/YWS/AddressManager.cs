using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressManager : MonoBehaviour
{
    protected static AddressManager instance;
    public static AddressManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (AddressManager)FindObjectOfType(typeof(AddressManager));

                if (instance == null)
                {
                    Debug.LogError("AddressManager Instance Error");
                }
            }

            return instance;
        }
    }

    public List<string> photoAddress = new List<string>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
