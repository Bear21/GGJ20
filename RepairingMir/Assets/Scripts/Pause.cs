using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour{


    public GameObject CanvasPaused;

    public void OpenPanel()
    {
        if (CanvasPaused != null)

        {
            bool isActive = CanvasPaused.activeSelf;

            CanvasPaused.SetActive(!isActive);
        }
    
    }



}
