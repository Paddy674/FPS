using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    public string _sceneName = string.Empty; //declare multiple scene names exist

    // if not triggered, message is hidden
    private bool hasWon = false;

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
            SceneManager.LoadScene(_sceneName);
        }
    }
}
