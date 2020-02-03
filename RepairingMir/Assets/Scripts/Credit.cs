using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour{


    public GameObject People;

    public void OpenPanel()
    {
        if(People != null)
        {
            bool isActive = People.activeSelf;

            People.SetActive(!isActive);
        }
    }



}
