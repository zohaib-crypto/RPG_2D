using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private bool _isMoving;
    private Vector2 _input;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!_isMoving)
        {
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");

            if (_input.x != 0) _input.y = 0;
            if (_input != Vector2.zero)
            {
                _animator.SetFloat("moveX", _input.x);
                _animator.SetFloat("moveY", _input.y);
                var targetPos = transform.position;
                targetPos.x += _input.x;
                targetPos.y += _input.y;
                StartCoroutine(Move(targetPos));
            }
        }
        _animator.SetBool("isMoving", _isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        _isMoving = false;
    }




}
