using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private int _key;

    public void AddKey()
    {
        _key++;
    }
    public bool CheckKey()
    {
        if (_key == 1)
            return true;
        else
            return false;
    }
}
