using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ForestEcoSystemBoids : MonoBehaviour
{

    public GameObject oakTree_Prefab;
    [Range(1, 100)]public int maxTrees;
    void Start()
    {
        
    }


    void Update()
    {

        

    }
    
    void FixedUpdate () {
        if (transform.childCount < maxTrees)
        {
            Vector3 rand = new Vector3(Random.Range(0, 200), 0, Random.Range(0, 200));
            rand.y = Terrain.activeTerrain.SampleHeight(rand)-5f;

            if (rand.y <= 0) return;
            Instantiate(oakTree_Prefab, rand, Quaternion.Euler(0,Random.Range(0f,360f),0), transform);
            

        }
    }
}
