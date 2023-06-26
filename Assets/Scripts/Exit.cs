using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _tutor;
    [SerializeField] private PlayerMovement _movement;

    void Start()
    {
        _button.onClick.AddListener(() => ExitTutor());
    }

    private void ExitTutor()
    {
        _movement.enabled = true;
        _tutor.gameObject.SetActive(false);
    }
}
