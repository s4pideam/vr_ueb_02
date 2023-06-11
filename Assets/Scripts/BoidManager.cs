using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoidManager : MonoBehaviour
{
    [Header ("Flock Settings")]
    public GameObject birdPrefab;
    [Range(1, 100)]public int numberOfBirds = 10;


    [Header("Goal Settings")] 
    public GameObject goal;
    [Range(1F, 10F)] public float strengthGoal = 1F; 
    [Range(1F, 10F)] public float radiusGoal = 1F;
    
    [Header("Boid Settings")] 
    [Range(1F, 10F)] public float speed = 5F;
    [Range(1F, 10F)] public float strenghtCenter = 1F; 
    [Range(1F, 10F)] public float radiusCenter = 1F; 
    [Range(1F, 10F)] public float strenghtAvoid = 1F; 
    [Range(1F, 10F)] public float radiusAvoid = 1F; 
    [Range(1F, 10F)] public float strenghtAlign = 1F; 
    [Range(1F, 10F)] public float radiusAlign = 1F;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate () {
        if (transform.childCount < numberOfBirds)
        {
            Vector2 rand = Random.insideUnitCircle * 50;
            Instantiate(birdPrefab, new Vector3(rand.x, 0.0f, rand.y), Quaternion.Euler(0,Random.Range(0f,360f),0), transform);


        }else if (transform.childCount > numberOfBirds)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }
    }   
}
