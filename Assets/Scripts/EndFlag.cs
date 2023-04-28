using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;
    public AudioClip finishLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(finishLevel, transform.position);
            if (lastLevel == true)
            {
                //AudioSource.PlayClipAtPoint(finishLevel, transform.position);
                SceneManager.LoadScene(0);
            }
            else
            {
                //AudioSource.PlayClipAtPoint(finishLevel, transform.position);
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

}
