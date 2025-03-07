using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttom : MonoBehaviour
{
    [SerializeField] AudioSource clickSFX;
    public void Buttom()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
