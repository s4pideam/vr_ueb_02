using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grow : MonoBehaviour
{
    private Vector3 adult;

    private float growRate ;

    
    void Start()
    {
        growRate = Random.Range(0.01f, 0.2f);
        adult = new Vector3(Random.Range(3f, 4f), Random.Range(3f, 4f), Random.Range(3f, 4f));
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.SqrMagnitude(adult - transform.localScale) < 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,  new Quaternion(transform.rotation.x,transform.rotation.y,90,transform.rotation.w) , Time.deltaTime*0.01f);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale,adult , Time.deltaTime*growRate);
        }
    }

    private void LateUpdate()
    {
        if (transform.rotation.z > 0.6f)
        {
            Destroy(gameObject);
        }
    }
}
