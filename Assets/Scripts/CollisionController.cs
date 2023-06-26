using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _movement;

    void OnCollisionEnter(Collision collis)
    {
        if (collis.gameObject.name == "groundSpike01")
        {
            _panelTutorial.SetActive(false);
            _movement.enabled = false;
            _animator.SetInteger("state", 3);
            _panelLose.SetActive(true);
        }
        else if (collis.gameObject.name == "Plane")
        {
            _panelTutorial.SetActive(false);
            _movement.enabled = false;
            _animator.SetInteger("state", 3);
            _panelLose.SetActive(true);
        }
        else if (collis.gameObject.name == "water01")
        {
            Debug.Log("fchgjbkn");
            _animator.SetInteger("state", 4);
        }
        else if (collis.gameObject.name == "ice")
        {
            Debug.Log("fchgjbkn");
            _movement.Movement(Vector3.forward, 3);
        }
        else if (collis.gameObject.name == "flagA")
        {
            _animator.SetInteger("state", 3);
            _panelWin.SetActive(true);
        }

    }
}
