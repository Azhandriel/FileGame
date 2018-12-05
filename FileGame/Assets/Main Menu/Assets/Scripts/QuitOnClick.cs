using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
        //ifUNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // else
            Application.Quit();
// #endif
    }
}
