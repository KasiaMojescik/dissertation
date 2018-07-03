using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // For scene 1
    public void PlayScene1()
    {
        SceneManager.LoadScene("Scene 1");
    }

    // Update is called once per frame
    public void PlayScene2()
    {
        SceneManager.LoadScene("Scene 2");
    }

    // Update is called once per frame
    public void PlayScene3()
    {
        SceneManager.LoadScene("Scene 3");
    }
}
