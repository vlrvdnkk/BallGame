using UnityEngine;
using System.Collections;
using TMPro;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _txtSpeed;
    [SerializeField] private TextMeshProUGUI _txtJump;
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private bool _jumping;
    private int _temp;
    public int state = 1;
    public int idle = 0;

    private void Start()
    {
        _speed = 3;
        _jumpSpeed = 4;
        _txtSpeed.text = Convert.ToString(_speed);
        _txtJump.text = Convert.ToString(_jumpSpeed);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Movement(Vector3.forward, state);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Movement(Vector3.back, state);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Movement(Vector3.left, state);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Movement(Vector3.right, state);
        }
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Space) & Input.anyKey == true)
        {
            if (_jumping == false)
            {
                _jumping = true;
                _temp = state;
                state = 2;
                _rb.AddForce(_player.transform.up * _jumpSpeed, ForceMode.Impulse);
            }
        }
        if (_jumping == false & Input.anyKey == false)
        {
            state = _temp;
            _animator.SetInteger("state", idle);
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

    public void AddSpeed (int num)
    {
        _speed += num;
        _txtSpeed.text = Convert.ToString(_speed);
    }

    public void AddJump (int num)
    {
        _jumpSpeed += num;
        _txtJump.text = Convert.ToString(_jumpSpeed);
    }
} 