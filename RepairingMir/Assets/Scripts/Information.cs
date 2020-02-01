using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour{


    public GameObject Info;

    public void OpenPanel()
    {
        if(Info != null)
        {
            bool isActive = Info.activeSelf;

            Info.SetActive(!isActive);
        }
    }



}
