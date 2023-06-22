using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _jumpSpeed = 8;
    [SerializeField] private bool _jumping;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += Vector3.forward * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position += Vector3.back * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumping == false)
            {
                _jumping = true;
                _rb.AddForce(_player.transform.up * _jumpSpeed, ForceMode.Impulse);
            }
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
} 