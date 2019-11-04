using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }
    // 2
    public void Quit()
    {
        Application.Quit();
    }

}
