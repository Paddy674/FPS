using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Have we won the game yet?
    private bool hasWon = false;

    // Describes how the win message should be displayed.
    public GUIStyle winMessageStyle;

    // Detects when we've entered the trigger and enables the text display.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasWon = true;
        }
    }

    /// A quick and dirty way to display a win message in the middle of the 
    /// current camera's view.
    void OnGUI()
    {
        if (hasWon)
        {
            GUI.Label(Camera.main.pixelRect, "You Escaped", winMessageStyle);
        }
    }
}
