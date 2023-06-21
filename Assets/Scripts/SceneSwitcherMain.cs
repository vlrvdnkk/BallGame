using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcherMain : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;
    [SerializeField] private TextMeshProUGUI _text;
    internal string _firstTime;

    void Start()
    {
        if (PlayerPrefs.GetString(_firstTime) == "1")
        {
            _text.text = "Continue";
            PlayerPrefs.SetString(_firstTime, "");
        }
        _button.onClick.AddListener(() => NextScene());  
    }
    private void NextScene()
    {
        PlayerPrefs.SetString(_firstTime, "1");
        PlayerPrefs.Save();
        SceneManager.LoadScene(_sceneName);
    }
}