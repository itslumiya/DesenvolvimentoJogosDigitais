using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arkanoid : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void StartGamePacific()
    {
        PlayerPrefs.SetString("GameMode", "Pacifico");
        SceneManager.LoadScene("Fase 1");
    }

    public void StartGameNormal()
    {
        PlayerPrefs.SetString("GameMode", "Normal");
        SceneManager.LoadScene("Fase 1");
    }
}
