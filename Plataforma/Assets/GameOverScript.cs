using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartGame()
    {
        var level = PlayerPrefs.GetString("LevelAtual");
        if(level == "Level1"){
            SceneManager.LoadScene("Level1");
        } else {
            SceneManager.LoadScene("Level2");
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
