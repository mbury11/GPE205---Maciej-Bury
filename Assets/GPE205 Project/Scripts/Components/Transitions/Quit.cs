using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitEditor()
    {
        EditorApplication.isPlaying = false;
    }
}
