using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField text;

    private void Start()
    {
        text.text = PersistentManager.pManager.Username;
    }

    public void StartGame()
    {
        PersistentManager.pManager.Username = text.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Aplication.Quit();
        #endif
    }
}
