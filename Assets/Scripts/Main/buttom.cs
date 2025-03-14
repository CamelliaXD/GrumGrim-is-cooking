using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class buttom : MonoBehaviour
{

    [SerializeField] AudioSource clickSFX;
    public void Buttom()
    {
        StartCoroutine(DelayBeforeLoadScene("Menu"));
    }
    public void Setting()
    {
        clickSFX.Play();
    }
    public void Quits()
    {
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(DelayBeforeLoadScene("SampleScene"));
    }

    IEnumerator DelayBeforeLoadScene(string sceneName)
    {
        EventSystem.current.SetSelectedGameObject(null);

        if (clickSFX != null)
        {
            clickSFX.Play();
        }

        yield return new WaitForSeconds(0.5f); 

        SceneManager.LoadScene(sceneName);
    }
 
}
