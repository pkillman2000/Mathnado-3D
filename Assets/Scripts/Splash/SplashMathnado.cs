using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashMathnado : MonoBehaviour
{
    [SerializeField]
    private Vector3 _startPosition;
    [SerializeField]
    private Vector3 _endPosition;
    [SerializeField]
    private float _duration;

    private float _speed;

    void Start()
    {
       this.transform.position = _startPosition;
        _speed =  Vector3.Distance(_startPosition, _endPosition)/_duration;
    }


    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, _endPosition, _speed * Time.deltaTime);
    }
}
