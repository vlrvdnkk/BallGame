using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BoostRotate : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private PlayerMovement _movement;

    void Update()
    {
        transform.eulerAngles += Vector3.up * speed * Time.deltaTime;
    }
}
