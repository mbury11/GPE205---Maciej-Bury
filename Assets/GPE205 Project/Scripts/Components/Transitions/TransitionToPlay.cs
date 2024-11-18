using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToPlay : MonoBehaviour
{
    public void GoToPlay()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateGameplay();
        }
    }
}
