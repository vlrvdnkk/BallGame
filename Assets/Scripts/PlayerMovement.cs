using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _jumpSpeed = 8;
    [SerializeField] private bool _jumping;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Movement(Vector3.forward, 1);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Movement(Vector3.back, 1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Movement(Vector3.left, 1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Movement(Vector3.right, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumping == false)
            {
                _jumping = true;
                _rb.AddForce(_player.transform.up * _jumpSpeed, ForceMode.Impulse);
                _animator.SetInteger("state", 2);
            }
        }
        if (_jumping == false)
        {
            _animator.SetInteger("state", 0);
        }
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * _speed;
        dir = Vector3.ClampMagnitude(dir, _speed);

        if (dir != Vector3.zero)
        {
            _rb.MovePosition(transform.position + dir * Time.deltaTime);
            _rb.MoveRotation(Quaternion.LookRotation(dir));
        }
    }
    void OnCollisionEnter(Collision collis)
    {
        if (collis.gameObject)
        {
            _jumping = false;
        }
    }
    public void Movement(Vector3 Vector3, int var)
    {
        _player.transform.position += Vector3 * _speed * Time.deltaTime;
        _animator.SetInteger("state", var);
    }
} 