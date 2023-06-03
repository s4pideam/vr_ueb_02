using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    private Scene _currentScene;
    void Start()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }

    void OnGUI()
    {
        int index = SceneManager.GetSceneAt(1).buildIndex;
        String labelText = String.Format("Current Scene: {0}",
            System.IO.Path.GetFileNameWithoutExtension(
                SceneUtility.GetScenePathByBuildIndex((index) % (SceneManager.sceneCountInBuildSettings - 1))));
        GUI.Label(new Rect(10, 10, 200, 20), labelText);
        if (GUI.Button(new Rect(10, 30, 130, 30), "Next Scene"))
        {
            if (SceneManager.sceneCount > 2) return;
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
            SceneManager.LoadScene( (index + 1) % (SceneManager.sceneCountInBuildSettings-1),LoadSceneMode.Additive);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
