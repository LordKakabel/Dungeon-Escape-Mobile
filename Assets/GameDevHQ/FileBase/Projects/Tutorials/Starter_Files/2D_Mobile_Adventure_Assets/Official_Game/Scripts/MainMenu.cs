using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _indexOfFirstScene = 1;

    public void StartButton()
    {
        SceneManager.LoadScene(_indexOfFirstScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
