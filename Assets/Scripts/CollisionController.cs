using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorFade;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private UiController _uiController;

    void OnCollisionEnter(Collision collis)
    {
        if (collis.gameObject.name == "groundSpike01")
        {
            _animatorFade.SetBool("faded", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider collid)
    {
        if (collid.gameObject.name == "water")
        {
            _movement.state = 4;
            _movement.idle = 4;
        }
        else if (collid.gameObject.name == "flag")
        {
            if (_uiController.CheckKey())
            {
                _movement.enabled = false;
                _animator.SetInteger("state", 3);
                _panelWin.SetActive(true);
            }
            else
            {

            }
        }
        else if (collid.gameObject.name == "Plane")
        {
            _animatorFade.SetBool("faded", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collid.gameObject.name == "pot")
        {
            _movement.AddSpeed(1);
            Destroy(collid.gameObject);
        }
        else if (collid.gameObject.name == "beer")
        {
            _movement.AddJump(1);
            Destroy(collid.gameObject);
        }
        else if (collid.gameObject.name == "key")
        {
            _uiController.AddKey();
            Destroy(collid.gameObject);
        }
    }
    private void OnTriggerExit(Collider collid)
    {
        if (collid.gameObject.name == "water")
        {
            _movement.state = 1;
            _movement.idle = 0;
        }
    }
}
