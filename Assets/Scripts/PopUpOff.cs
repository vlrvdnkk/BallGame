using UnityEngine;
using UnityEngine.UI;

public class PopUpOff : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _buttonOpt;
    [SerializeField] private Canvas _canvasPopUp;

    void Start()
    {
        _button.onClick.AddListener(() => PopUp());
    }

    private void PopUp()
    {
        _canvasPopUp.gameObject.SetActive(false);
        _buttonOpt.gameObject.SetActive(true);
    }
}
