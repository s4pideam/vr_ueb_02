using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ForestEcoSystem : MonoBehaviour
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
            UnityEngine.Vector2 rand = Random.insideUnitCircle * 50;
            Instantiate(oakTree_Prefab, new Vector3(rand.x, 0.0f, rand.y), Quaternion.Euler(0,Random.Range(0f,360f),0), transform);

        }
    }
}
