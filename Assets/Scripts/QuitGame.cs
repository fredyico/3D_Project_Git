using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitting application");
    }
}
