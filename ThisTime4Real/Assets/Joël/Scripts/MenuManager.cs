using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<UIManager>().menuScreen.SetActive(false);
    }
    public void Options()
    {
        GetComponent<UIManager>().menu.SetActive(false);
        GetComponent<UIManager>().optionScreen.SetActive(true);
    }
    public void Back()
    {
        GetComponent<UIManager>().menu.SetActive(true);
        GetComponent<UIManager>().optionScreen.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
