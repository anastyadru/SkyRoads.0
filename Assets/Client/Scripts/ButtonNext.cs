using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    public bool NextGame;
    private GameObject nextGameMenu;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}