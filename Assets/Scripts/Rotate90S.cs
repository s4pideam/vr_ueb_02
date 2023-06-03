using UnityEngine;

public class Rotate90S : MonoBehaviour
{
    
    private float _degreesPerSecond = 90.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, _degreesPerSecond * Time.deltaTime, 0);
    }
}
