using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCControll : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rSpeed;
    public UnityEvent<GameObject> restart;
    private Rigidbody _rigidbody;
    private float _rotate;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rotate = Random.Range(-20f, 20f);
        transform.Rotate(Vector3.up * _rotate * _rSpeed);
        StartCoroutine(NextRotation());
        
    }
    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.forward * _speed * Time.fixedDeltaTime);


    }
    void Update()
    {
        
        print(_rotate);
    }
    IEnumerator NextRotation()
    {
        yield return new WaitForSeconds(Random.Range(1f, 10f));
        _rotate = Random.Range(-20f, 20f);
        transform.Rotate(Vector3.up * _rotate * _rSpeed);
        StartCoroutine(NextRotation());
    }
    public void Restart()
    {
        restart.Invoke(gameObject);
    }

}
