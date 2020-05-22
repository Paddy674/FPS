using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // if not triggered, message is hidden
    private bool hasWon = false;

    // setup display message
    public GUIStyle winMessageStyle;

    // player enters trigger using tag
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasWon = true;
        }
    }

    void OnGUI()
    {
        if (hasWon)
        {
            GUI.Label(Camera.main.pixelRect, "You Escaped", winMessageStyle);
        }
    }
}
