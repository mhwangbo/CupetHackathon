using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public void ToShelter()
    {
        SceneManager.LoadScene("Shelter");
    }

    public void ToMap()
    {
        SceneManager.LoadScene("ARMap");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
