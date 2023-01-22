using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleHuman : MonoBehaviour
{
    [SerializeField, Header("ê∂ìkÇ»ÇÁOn")]
    private bool isStudent = true;

    private bool appQuit = false;

    private void OnBecameVisible()
    {
        if(isStudent)
        {
            Player.Instance.students.AddLast(gameObject);

        }
        else
        {

            Player.Instance.others.AddLast(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if(!appQuit)
        {
            if (isStudent)
            {
                Player.Instance.students.Remove(gameObject);

            }
            else
            {
                Player.Instance.others.Remove(gameObject);
            }

        }
    }


    private void OnApplicationQuit()
    {
        appQuit = true;
    }
}
