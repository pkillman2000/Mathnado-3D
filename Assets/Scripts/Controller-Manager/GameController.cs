using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will have overall control of the game.
 * It will call the scenen manager and UI manger
 * It will keep track of scores, win/loss, any events
*/

public class GameController : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
