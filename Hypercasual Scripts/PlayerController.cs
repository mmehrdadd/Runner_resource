using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f , sideSpeed = 1f;
    public bool isRunning;

    [HideInInspector]
    public Transform transform;
    
    
    private Rigidbody _rb;
    private float _movingToSides;

    private void Start()
    {
        transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        //_rb.isKinematic = true;
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        
        _movingToSides = Input.GetAxis("Horizontal") * Time.deltaTime;        
        transform.Translate(new Vector3(_movingToSides * sideSpeed, 0f, moveSpeed * Time.deltaTime));
        
    }
}
