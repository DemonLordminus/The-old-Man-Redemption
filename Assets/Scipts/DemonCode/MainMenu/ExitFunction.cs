using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitFunction : MonoBehaviour
{
    // Start is called before the first frame update
   public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
