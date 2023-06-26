using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoNextScene : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SceneSwitcherMain _sceneM;

    void Start()
    {
        _button.onClick.AddListener(() => NextScene());
    }
    public void NextScene()
    {
        PlayerPrefs.SetString(_sceneM._firstTime, "1");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
