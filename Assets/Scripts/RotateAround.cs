using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [Range(-180F, 180F)]
    public float degreesPerSecond = 90.0f;
    
    [Range(1F, 10F)]
    public float velocity = 5.0f;
    
    public GameObject target;

    private Vector3 _startPosition;
    private float _flyHeight = .5f;

    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, degreesPerSecond * Time.deltaTime);
        transform.position = new Vector3(transform.position.x,_startPosition.y + _flyHeight*Mathf.Sin(Time.time*velocity),transform.position.z);
    }
}
