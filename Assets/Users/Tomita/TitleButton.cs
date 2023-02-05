using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
   
       public void GetMouseButtonDown()
       {
            {
                SceneManager.LoadScene("Game");
            }
        }

    
}
