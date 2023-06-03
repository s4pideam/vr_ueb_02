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
        if (GUI.Button(new Rect(10, 10, 400, 30), String.Format("Next Scene ({0})",System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex((index + 1) % (SceneManager.sceneCountInBuildSettings-1))))))
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
