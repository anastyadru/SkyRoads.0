// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    public bool NextGame;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}