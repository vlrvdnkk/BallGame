using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;
    [SerializeField] private SceneSwitcherMain _sceneM;

    void Start()
    {
        _button.onClick.AddListener(() => NextScene());
    }
    private void NextScene()
    {
        PlayerPrefs.SetString(_sceneM._firstTime, "1");
        PlayerPrefs.Save();
        SceneManager.LoadScene(_sceneName);
    }
}