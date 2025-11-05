using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    [SerializeField]
    private float _moveSpeed;
    void Start()
    {

    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(_horizontalInput, _verticalInput) * _moveSpeed * Time.deltaTime);
    }
}
