using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter_Controller : MonoBehaviour
{
    public GameObject NextNote = null;
    void Update()
    {
        GameObject temp = GameObject.FindWithTag("Note");

        // Debug.Log($"Is temp null? {temp == null}");

        if (temp != null)
        {
            NextNote = temp;
            // Debug.Log($"Is NextNote null? {NextNote == null}");
            // Debug.Log($"This's Game Object: {this.gameObject}");
        }
        else
        {
            NextNote = null;
        }
    }

    public void DestroyOther()
    {
        Debug.Log(NextNote.GetComponent<Note_Controller>().GetCanBeDestroyed());
        if (NextNote.GetComponent<Note_Controller>().GetCanBeDestroyed())
        {
            NextNote.GetComponent<Note_Controller>().DestroyThisObject();
        }
    }
}
