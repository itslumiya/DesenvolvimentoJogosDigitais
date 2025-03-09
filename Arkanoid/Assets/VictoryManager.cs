using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    void Start()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");
        var labelVitoria = GameObject.FindWithTag("LabelVictory").GetComponent<UnityEngine.UI.Text>();
        labelVitoria.text = "Você venceu a fase " + level + "!";

        var buttonPreviousLevel = GameObject.FindWithTag("ButtonPreviousLevel").GetComponent<UnityEngine.UI.Button>();
        var buttonReplayLevel = GameObject.FindWithTag("ButtonReplayLevel").GetComponent<UnityEngine.UI.Button>();
        var buttonNextLevel = GameObject.FindWithTag("ButtonNextLevel").GetComponent<UnityEngine.UI.Button>();

        if (level == 1)
        {
            buttonPreviousLevel.gameObject.SetActive(false);
            buttonReplayLevel.gameObject.SetActive(true);
            buttonNextLevel.gameObject.SetActive(true);
        }
        else if (level == 2)
        {
            buttonPreviousLevel.gameObject.SetActive(true);
            buttonReplayLevel.gameObject.SetActive(true);
            buttonNextLevel.gameObject.SetActive(true);
        }
        else
        {
            buttonPreviousLevel.gameObject.SetActive(true);
            buttonReplayLevel.gameObject.SetActive(true);
            buttonNextLevel.gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void PreviousLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int previousLevel = currentLevel - 1;

        string previousSceneName = "Fase " + previousLevel;
        if (SceneManager.GetSceneByName(previousSceneName) != null)
        {
            PlayerPrefs.SetInt("CurrentLevel", previousLevel);
            SceneManager.LoadScene(previousSceneName);
        }
    }

    public void NextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int nextLevel = currentLevel + 1;

        string nextSceneName = "Fase " + nextLevel;
        if (SceneManager.GetSceneByName(nextSceneName) != null)
        {
            PlayerPrefs.SetInt("CurrentLevel", nextLevel);
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void ReplayLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        string scene = "Fase " + currentLevel;
        if (SceneManager.GetSceneByName(scene) != null)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
