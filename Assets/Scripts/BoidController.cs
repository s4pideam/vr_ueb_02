using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoidController : MonoBehaviour
{

    public GameObject boidPrefab;
    [Range(1, 100)] public int numberBoids = 5;
    [Range(1, 50)] public float sphereRadius = 5;

    private List<GameObject> boidsInScene;
    
    [Range(0.1f, 20.0f)]
    public float velocity = 6.0f;

    [Range(0.0f, 0.9f)]
    public float velocityVariation = 0.5f;

    [Range(0.1f, 20.0f)]
    public float rotationCoeff = 4.0f;

    [Range(0.1f, 10.0f)]
    public float neighborDist = 2.0f;

    public LayerMask searchLayer;

    public GameObject forest;
    
    private GameObject _target;
    public GameObject _flock;

    // Start is called before the first frame update
    void Start()
    {
        // Set position before spawning Boids
        transform.position = new Vector3(100, sphereRadius + 15, 100);
        
        // Spawn Boids
        boidsInScene = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        // Adjustable Number of Boids during runtime
        if(boidsInScene.Count < numberBoids)
        {
            var boid = Instantiate(boidPrefab,
                transform.position + Random.insideUnitSphere * sphereRadius,
                Random.rotation,_flock.transform);
            boid.GetComponent<BoidBehaviour>().boidController = this;
            boidsInScene.Add(boid);
        }
        if(boidsInScene.Count > numberBoids)
        {
            Destroy(boidsInScene[0]);
            boidsInScene.RemoveAt(0);
        }
        
        
        // Let Boids fly to and over biggest tree
        if (!_target)
        {
            if (forest.transform.childCount != 0)
            {
                GameObject biggest = forest.transform.GetChild(0).gameObject;
                for (int i = 0; i < forest.transform.childCount; i++)
                {
                    if (biggest.transform.localScale.magnitude < forest.transform.GetChild(i).localScale.magnitude)
                    {
                        biggest = forest.transform.GetChild(i).gameObject;
                    }
                }

                _target = biggest;
            }
            return;
        }
        Vector3 moveTo = new Vector3(_target.transform.position.x,_target.transform.position.y + _target.transform.localScale.magnitude + sphereRadius,_target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, moveTo, velocity* .75f * Time.deltaTime);
        
        
    }
}
