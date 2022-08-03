using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _planet;
    private Vector3 _dist;
    private Vector3 _rotDist;
    void Start()
    {
        _dist = transform.position - _target.position;
        _rotDist = transform.eulerAngles - _target.eulerAngles;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

    }

}