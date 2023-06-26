using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    [SerializeField] private TextMeshProUGUI _txtKey;
    [SerializeField] private int _key;
    [SerializeField] private int _lvl;

    private void Start()
    {
        _lvl = PlayerPrefs.GetInt("_lvl");
        if (_lvl == 1)
        {
            _button2.enabled = true;
            _button2.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        else if (_lvl == 2)
        {
            _button2.enabled = true;
            _button2.GetComponent<Image>().color = new Color(255, 255, 255);
            _button3.enabled = true;
            _button3.GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }
    public void AddKey()
    {
        _key++;
        _txtKey.text = Convert.ToString(_key);
    }
    public void AddLevel()
    {
        _lvl++;
        PlayerPrefs.SetInt("_lvl", _lvl);
        PlayerPrefs.Save();
    }
    public bool CheckKey()
    {
        if (_key == 1)
            return true;
        else
            return false;
    }
    public int CheckLvl()
    {
        return _lvl;
    }
}
