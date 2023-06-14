using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    
    public BoidController boidController;
    
    
    // Random seed.
    float noiseOffset;

    // Caluculates the separation vector with a target.
    Vector3 GetSeparationVector(Transform target)
    {
        var diff = transform.position - target.transform.position;
        var diffLen = diff.magnitude;
        var scaler = Mathf.Clamp01(1.0f - diffLen / boidController.neighborDist);
        return diff * (scaler / diffLen);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        noiseOffset = Random.value * 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;
        var currentRotation = transform.rotation;

        // Current velocity randomized with noise.
        var noise = Mathf.PerlinNoise(Time.time, noiseOffset) * 2.0f - 1.0f;
        var velocity = boidController.velocity * (1.0f + noise * boidController.velocityVariation);

        // Initializes the vectors for separation, allignment and cohesion.
        var separation = Vector3.zero;
        var alignment = boidController.transform.forward;
        var cohesion = boidController.transform.position;

        // Looks up nearby boids.
        var nearbyBoids = Physics.OverlapSphere(currentPosition, boidController.neighborDist, boidController.searchLayer);

        // Accumulates the vectors.
        foreach (var boid in nearbyBoids)
        {
            if (boid.gameObject == gameObject) continue;
            var t = boid.transform;
            separation += GetSeparationVector(t);
            alignment += t.forward;
            cohesion += t.position;
        }

        var avg = 1.0f / nearbyBoids.Length;
        alignment *= avg;
        cohesion *= avg;
        cohesion = (cohesion - currentPosition).normalized;

        // Calculates the direction.
        var direction = separation + alignment + cohesion;
        
        // If boid leaves the Sphere, bring him back
        var distanceToCenter = Vector3.Distance(transform.position, boidController.transform.position);
        if (distanceToCenter > boidController.sphereRadius)
        {
            direction += transform.position.normalized * ((boidController.sphereRadius - distanceToCenter) * Time.deltaTime);
        }
        
        
        // Calculate a rotation
        var rotation = Quaternion.FromToRotation(Vector3.forward, direction.normalized);

        // Applys the rotation with interpolation.
        if (rotation != currentRotation)
        {
            var ip = Mathf.Exp(-boidController.rotationCoeff * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(rotation, currentRotation, ip);
        }

        // Moves forawrd.
        transform.position = currentPosition + transform.forward * (velocity * Time.deltaTime);
    }
}
