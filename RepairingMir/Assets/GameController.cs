using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float EndTime = 300.0f ;
    bool EndGameHappened = false;
    public float FirstRadio = 15.0f;
    bool FirstRadioHappened = false;
    public float RadioHurryUp = 270.0f;
    bool RadioHurryUpHappened = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = Time.timeSinceLevelLoad;
        if (!EndGameHappened && time >= EndTime)
        {
            EndGameHappened = true;
            ShowEnding();
        }
        if (!FirstRadioHappened && time >= FirstRadio)
        {
            FirstRadioHappened = true;

        }
        if (!RadioHurryUpHappened && time >= RadioHurryUp)
        {
            RadioHurryUpHappened = true;

        }
    }

    void ShowEnding()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void DroppedItem(GameObject obj)
    {
        // probably a fuse.
    }
}
