using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlider : MonoBehaviour
{
    [Range(-180F, 180F)]
    public float degreesPerSecond = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
    }
}
