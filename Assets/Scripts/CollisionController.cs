using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorFade;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private UiController _uiController;
    [SerializeField] private int _count = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("_count") >= 1)
        {
            _count = PlayerPrefs.GetInt("_count");
        }
        else
        {
            _count = 0;
            PlayerPrefs.SetInt("_count", 0);
        }
    }
    void OnCollisionEnter(Collision collis)
    {
        if (collis.gameObject.name == "groundSpike01")
        {
            _animatorFade.SetBool("faded", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collis.gameObject.name == "bridgeWooden" & PlayerPrefs.GetInt("_count") == 0)
        {
            _text.text = "Воробушки - это умные птицы, но им очень тяжело выживать на улице. " +
                "Сейчас перед собой ты увидел Васяна - гениального воробушка и наследника Чирик Гейтса" +
                " в пятом поколении. Недавно хулиганы подбили ему крылышко, поэтому за едой ему придется добираться непростым путём, " +
                "прыгая по различным предметам. Впрочем, ты ему в этом и поможешь. Управление на WASD или стрелочками, прыжок на SPACE. Удачи!";
            AllStop();

        }
        else if (collis.gameObject.name == "bench" & PlayerPrefs.GetInt("_count") == 1)
        {
            _text.text = "А вот и первый подарочек - кастрюлька! А что в ней - неважно, главное, съедобное! " +
                "Еда повышает твою скорость на одну воробьиную силу. Обычный воробушек бегает с тройной воробьиной силой. Подбирай скорее!";
            AllStop();
        }
        else if (collis.gameObject.name == "bridgeWoodenRails" & PlayerPrefs.GetInt("_count") == 2)
        {
            _text.text = "Чтобы пройти на следующий уровень, необходимо каждый раз собирать такой ключик." +
                "Обычно он расположен в самых опасных местах, поэтому не упади на шипы! Они не только поранят второе крылышко, " +
                "но и проткнут твою пернатую попку... Так что, приземлись ккуда-нибудь ещё, пожалуйста";
            AllStop();
        }
        else if (collis.gameObject.name == "bridgeWooden01" & PlayerPrefs.GetInt("_count") == 3)
        {
            _text.text = "Ура, это бассейн с холодным пенным! Напитки повышают высоту твоего прыжка на одну воробьиную силу. " +
                "Обычный воробушек прыгает с четверной воробьиной силой. Поплавай с удовольствием!";
            AllStop();
        }
        else if (collis.gameObject.name == "wallEarth01" & PlayerPrefs.GetInt("_count") == 4)
        {
            _text.text = "Ого, впереди чекпоинт! Он приведет тебя на следующий уровень! " +
                "На этом мы с тобой не прощаемся ;) Надеюсь, ты поможешь Васяну пройти все испытания, удачи!";
            AllStop();
        }
    }
    private void OnTriggerEnter(Collider collid)
    {
        if (collid.gameObject.name == "water")
        {
            _movement.state = 4;
            _movement.idle = 4;
        }
        else if (collid.gameObject.name == "flag")
        {
            if (_uiController.CheckKey())
            {
                _movement.enabled = false;
                _animator.SetInteger("state", 3);
                _panelWin.SetActive(true);
            }
            else
            {

            }
        }
        else if (collid.gameObject.name == "Plane")
        {
            _animatorFade.SetBool("faded", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collid.gameObject.name == "pot")
        {
            _movement.AddSpeed(1);
            Destroy(collid.gameObject);
        }
        else if (collid.gameObject.name == "beer")
        {
            _movement.AddJump(1);
            Destroy(collid.gameObject);
        }
        else if (collid.gameObject.name == "key")
        {
            _uiController.AddKey();
            Destroy(collid.gameObject);
        }
    }

    private void OnTriggerExit(Collider collid)
    {
        if (collid.gameObject.name == "water")
        {
            _movement.state = 1;
            _movement.idle = 0;
        }
    }

    private void AllStop()
    {
        _movement.enabled = false;
        _panelTutorial.SetActive(true);
        _animator.SetInteger("state", 0);
        _count++;
        PlayerPrefs.SetInt("_count", _count);
        PlayerPrefs.Save();
    }
}
