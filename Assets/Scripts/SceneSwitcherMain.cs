using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcherMain : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private UiController _ui;
    internal string _firstTime;

    void Start()
    {
        if (PlayerPrefs.GetString(_firstTime) == "1")
        {
            _text.text = "Continue";
            PlayerPrefs.SetString(_firstTime, "");
        }
        if (_ui.CheckLvl() == 1)
            _button.onClick.AddListener(() => NextScene("Lvl2"));  
        if (_ui.CheckLvl() == 2)
            _button.onClick.AddListener(() => NextScene("Lvl3"));  
        else
            _button.onClick.AddListener(() => NextScene("Lvl1"));  
    }
    private void NextScene(string scene)
    {
        PlayerPrefs.SetString(_firstTime, "1");
        PlayerPrefs.Save();
        SceneManager.LoadScene(scene);
    }
}