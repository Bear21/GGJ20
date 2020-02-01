using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour{


    public GameObject CanvasCredits;

    public void CreditsCanvas()
    {
        if (CanvasCredits != null)

        {
            bool isActive = CanvasCredits.activeSelf;

            CanvasCredits.SetActive(!isActive);
        }
    
    }



}
