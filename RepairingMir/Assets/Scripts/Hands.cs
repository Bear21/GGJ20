using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public GameObject SelectionPrefab;
    private GameObject Selection;
    private bool HandsFull = false;
    private GameObject HeldObject = null;
    // Start is called before the first frame update
    void Start()
    {
        Selection = null;
        HeldObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!HandsFull)
        {
            if (!other.CompareTag("Pickupable"))
            {
                return;
            }

            KillSelection();


            Selection = Instantiate(SelectionPrefab, other.transform);
            Selection.transform.position = other.transform.position;
            Selection.transform.localScale = other.bounds.size;
            Selection.GetComponent<SelectionScript>().SelectedItem = other.gameObject;
        }
        else
        {
            if (!other.CompareTag("Dropable"))
            {
                return;
            }

            KillSelection();

            Selection = Instantiate(SelectionPrefab, other.transform);
            Selection.transform.position = other.transform.position;
            Selection.transform.localScale = other.bounds.size;
            Selection.GetComponent<SelectionScript>().SelectedItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Pickupable") && !other.CompareTag("Dropable"))
        {
            return;
        }
        KillSelection();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Use") != 0.0f)
        {
            Debug.Log("F");
            if (Selection)
            {
                if (!HandsFull)
                {
                    Debug.Log("PICKUP");
                    // Select
                    HeldObject = Selection.GetComponent<SelectionScript>().SelectedItem;
                    HeldObject.transform.SetParent(transform);
                    HeldObject.transform.localPosition = new Vector3(0, 0, 0);
                    HandsFull = true;
                    KillSelection();
                }
                else
                {
                    Debug.Log("DROP");
                    GameObject item = Selection.GetComponent<SelectionScript>().SelectedItem;
                    HeldObject.transform.SetParent(item.transform);
                    HeldObject.transform.localRotation = Quaternion.identity;
                    HeldObject.transform.localPosition = new Vector3(0, 0, 0);

                    HandsFull = false;
                    HeldObject.GetComponent<Collider>().enabled = false;
                    HeldObject = null;
                    KillSelection();
                }
            }
        }
    }

    private void KillSelection()
    {
        if (Selection)
        {
            Debug.Log("Destroy selection");
            Destroy(Selection);
            Selection = null;
        }
    }
}
