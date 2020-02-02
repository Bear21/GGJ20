using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float EndTime = 300.0f ;
    bool EndGameHappened = false;
    public float FirstRadio = 1.0f;
    bool FirstRadioHappened = false;
    public float SecondRadio = 30.0f;
    bool SecondRadioHappened = false;
    public float RadioHurryUp = 270.0f;
    bool RadioHurryUpHappened = false;

    public float WinTime = 10000.0f;

    public AudioClip Radio1;
    public AudioClip Radio2;
    public AudioClip Radio3;
    public AudioClip Radio4;
    public AudioClip Radio5;
    public AudioClip Radio6;
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
            AudioSource.PlayClipAtPoint(Radio1, new Vector3(0, 0, 0), 20.0f);
        }
        if (!SecondRadioHappened && time >= SecondRadio)
        {
            SecondRadioHappened = true;
            AudioSource.PlayClipAtPoint(Radio2, new Vector3(0,0,0), 2.0f);
        }
        if (!RadioHurryUpHappened && time >= RadioHurryUp)
        {
            RadioHurryUpHappened = true;
            AudioSource.PlayClipAtPoint(Radio6, new Vector3(0, 0, 0), 2.0f);
        }
        if (time >= WinTime)
        {
            ShowWin();
        }
    }

    void ShowEnding()
    {
        SceneManager.LoadScene("Main Menu");

    }

    void ShowWin()
    {
        SceneManager.LoadScene("EndScene");

    }

    public void DroppedItem(GameObject obj)
    {

        // probably a fuse.
        AudioSource.PlayClipAtPoint(Radio5, new Vector3(0, 0, 0), 2.0f);

        WinTime = Time.timeSinceLevelLoad + 5.0f;

        EndTime += 20.0f;
    }
}
