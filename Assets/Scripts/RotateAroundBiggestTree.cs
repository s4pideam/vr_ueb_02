using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAroundBiggestTree : MonoBehaviour
{
    
    [Range(1F, 10F)] public float velocity = 5.0f;
    [Range(-180F, 180F)] public float degreesPerSecond = 90.0f;
    // Start is called before the first frame update
    public GameObject forest;
    private GameObject _target;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        
        Vector3 moveTo = _target.transform.position;
        moveTo.y += _target.GetComponent<MeshRenderer>().bounds.max.y/2.0f;
        Vector3 direction;
        if (Vector3.Distance(transform.position, moveTo) >= 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, velocity * Time.deltaTime);
        }else{
            transform.RotateAround(_target.transform.position, Vector3.up, degreesPerSecond * Time.deltaTime);
        }

        direction = (moveTo- transform.position).normalized;          
        if (direction == Vector3.zero) return;
        Quaternion rotateTo = Quaternion.LookRotation(direction);
        rotateTo  = Quaternion.Euler(30, rotateTo.eulerAngles.y, rotateTo.eulerAngles.z); 

        transform.rotation = Quaternion.Lerp(transform.rotation,rotateTo,Time.deltaTime*5f);
        
        


    }


}
