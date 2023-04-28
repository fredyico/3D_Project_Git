using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public AudioClip PlaySound;
    public AudioClip QuitSound;

    public void onPlayButton()
    {
        AudioSource.PlayClipAtPoint(PlaySound, transform.position);
        SceneManager.LoadScene(1);
    }

    public void onQuitButton()
    {
        AudioSource.PlayClipAtPoint(QuitSound, transform.position);
        Application.Quit();
    }
}
