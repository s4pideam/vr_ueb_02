using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowBoid : MonoBehaviour
{
    public GameObject target;
    [Range(1, 100)] public int distance = 25;

    
    // Start is called before the first frame update

    Vector3 getCeneter()
    {
        Vector3 center = Vector3.zero;
        for (int i = 0; i < target.transform.childCount; i++)
        {
            center += target.transform.GetChild(i).position;
        }

        return center / target.transform.childCount;
    }

    void Start()
    {
        if (target.transform.childCount == 0) return;
        Vector3 center = getCeneter();
        transform.position = center+ new Vector3(distance, distance, distance);
        transform.rotation = Quaternion.LookRotation((center - transform.position).normalized);

    }

    private void Update()
    {
        if (target.transform.childCount == 0) return;
        Vector3 center = getCeneter();
        transform.position = Vector3.Lerp(transform.position,center+  new Vector3(distance, distance, distance),Time.deltaTime*2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((center - transform.position).normalized), Time.deltaTime*2f);
    }
}
