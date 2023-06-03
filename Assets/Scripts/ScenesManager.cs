using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    // Start is called before the first frame update
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("/Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        //SceneManager.LoadScene("AufgabenteilB", LoadSceneMode.Additive);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        {
            Debug.Log("Scene2 loading: " + scenePaths[0]);
            SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
