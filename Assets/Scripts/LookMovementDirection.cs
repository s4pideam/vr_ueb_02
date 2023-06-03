using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMovementDirection : MonoBehaviour
{

    private Vector3 _oldPosition;
    void Start()
    {
        _oldPosition = transform.position;
    }
    
    void Update()
    {
        //
        
    }

    private void LateUpdate()
    {
        _oldPosition.y = transform.position.y;
        Vector3 direction = (transform.position - _oldPosition).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        _oldPosition = transform.position;
    }
}