using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Testing_Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
