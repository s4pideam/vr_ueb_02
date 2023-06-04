using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private enum CameraMode {First, Third, Vogel};
    private CameraMode _cameraMode;

    private Vector3 _oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        _cameraMode = CameraMode.Vogel;
        _oldPosition = target.position;

        
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            int modes = Enum.GetValues(typeof(CameraMode)).Length;
            _cameraMode = (CameraMode)(((int)_cameraMode+1) % modes);
            
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (_cameraMode)
        {
            case CameraMode.First:
                
                transform.position = target.position;
                transform.rotation = Quaternion.Euler(0, target.eulerAngles.y, target.eulerAngles.z);
                break;
            case CameraMode.Third:
                _oldPosition.y = target.position.y;
                Vector3 direction = (target.position - _oldPosition).normalized;
                transform.position = Vector3.Lerp(transform.position,target.transform.position - (direction * 5f),Time.deltaTime*2f);
                if (direction == Vector3.zero) break;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime*2f);
                break;
            case CameraMode.Vogel:
                transform.position = target.transform.position + new Vector3(0, 10, 0);
                transform.rotation = Quaternion.LookRotation(Vector3.down);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        _oldPosition = target.position;
 
    }
}
