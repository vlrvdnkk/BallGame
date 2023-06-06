using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;

    void Start()
    {
        _button.onClick.AddListener(() => NextScene());
    }
    private void NextScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}