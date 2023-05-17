using UnityEngine;
using UnityEngine.UI;

public class PopUpOn : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Canvas _canvasPopUp;

    void Start()
    {
        _button.onClick.AddListener(() => PopUp());
    }

    private void PopUp()
    {
        _canvasPopUp.gameObject.SetActive(true);
        _button.gameObject.SetActive(false);
    }
}