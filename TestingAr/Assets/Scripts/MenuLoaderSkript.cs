using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoaderSkript : MonoBehaviour
{
    public GameObject menuPanel;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PanelOn()
    {
        menuPanel.SetActive(true);
    }

    public void PanelOff()
    {
        menuPanel.SetActive(false);
    }

}
