using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatManager : MonoBehaviour
{
    void Start()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");
        var buttonReplayLevel = GameObject.FindWithTag("ButtonReplayLevel").GetComponent<UnityEngine.UI.Button>();
        buttonReplayLevel.gameObject.SetActive(true);
    }

    void Update()
    {

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
