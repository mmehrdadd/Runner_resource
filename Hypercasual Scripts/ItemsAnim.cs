using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAnim : MonoBehaviour
{
    private Transform _transform;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        _transform.Rotate(new Vector3(100f * Time.deltaTime, 100f * Time.deltaTime, 0f));
    }
}
