using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] AudioSource clickSFX;
    public void BackToMain()
    {
        StartCoroutine(DelayBeforeLoadScene("Main"));
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
