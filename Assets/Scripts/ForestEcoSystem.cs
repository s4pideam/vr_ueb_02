using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ForestEcoSystem : MonoBehaviour
{
    public GameObject oakTree_Prefab;

    private int MAX_TREES = 10;
    void Start()
    {
        
    }


    void Update()
    {

        

    }
    
    void FixedUpdate () {
        if (transform.childCount < MAX_TREES)
        {
            UnityEngine.Vector2 rand = Random.insideUnitCircle * 50;
            Instantiate(oakTree_Prefab, new Vector3(rand.x, 0.0f, rand.y), Quaternion.Euler(0,Random.Range(0f,360f),0), transform);

        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            
        }
    }
}
