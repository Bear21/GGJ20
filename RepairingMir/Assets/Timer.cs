using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image o2forground;
    public float maxTime = 5f;
    float timeLeft;
   
    // Start is called before the first frame update
    void Start()
    {
       
        o2forground = GetComponent<Image>();
        timeLeft = maxTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            o2forground.fillAmount = timeLeft / maxTime;

        }
    }
}
