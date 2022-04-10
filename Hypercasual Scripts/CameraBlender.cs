using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraBlender : MonoBehaviour
{
    [SerializeField]
    bool firstTrigger, secondTrigger, thirdTrigger;
    [SerializeField]
    private CinemachineVirtualCamera _camera1, _camera2, _camera3;

    private void OnEnable()
    {
        CameraEvent.onBackToRunner += CameraBackToRunner;
    }
    private void OnDisable()
    {
        CameraEvent.onBackToRunner -= CameraBackToRunner;
    }
    private void CameraBackToRunner()
    {
        _camera2.Priority = _camera1.Priority - 1;
    }
    private void OnTriggerEnter(Collider obj)
    {
        
        if(firstTrigger && obj.CompareTag(TagHolder.player))
        {
            _camera2.Priority = _camera1.Priority + _camera3.Priority + 1;
        }            
        if(secondTrigger && obj.CompareTag(TagHolder.player))
        {            
            _camera3.Priority = _camera1.Priority + _camera2.Priority + 1;
        }
        if(thirdTrigger && obj.CompareTag(TagHolder.player))
        {
            _camera1.Priority = _camera2.Priority + _camera3.Priority + 1;
        }
    }
}

public class CameraEvent
{    
    public static event Action onBackToRunner; 

    private void BackToRunner()
    {
        onBackToRunner?.Invoke();
    }
}
