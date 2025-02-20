using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttomongame1 : MonoBehaviour
{
    [SerializeField] AudioSource clickSFX;
    public void Button()
    {
        SceneManager.LoadScene("SampleScene");
    }
}