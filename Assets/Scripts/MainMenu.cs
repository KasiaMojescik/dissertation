using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // For scene 1
    public void PlayArrow()
    {
        SceneManager.LoadScene("Just Arrow");
    }

    // Update is called once per frame
    public void PlayVoice()
    {
        SceneManager.LoadScene("Just Sound");
    }

    // Update is called once per frame
    public void PlayHaptic()
    {
        SceneManager.LoadScene("Just Haptic");
    }

    public void PlayArrowVoice()
    {
        SceneManager.LoadScene("Arrow and Voice");
    }

    public void PlayArrowHaptic()
    {
        SceneManager.LoadScene("Arrow and Haptic");
    }
    
    public void PlaySingleArrow()
    {
        SceneManager.LoadScene("Single Arrow");
    }

    public void PlayLine()
    {
        SceneManager.LoadScene("Line");
    }
}
