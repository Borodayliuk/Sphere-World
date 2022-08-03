using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rSpeed = 1;
    private Rigidbody _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * _rSpeed);
        
    }
    private void FixedUpdate()
    {

        _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.forward * _speed * Time.fixedDeltaTime);
        //_rigidbody.velocity = transform.forward * _speed;

    }
    public void Restart()
    {
        GetComponent<AddBlock>().Restart();
    }

}
