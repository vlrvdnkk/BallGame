using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
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
                "Сейчас перед собой ты увидел гениального воробушка и наследника Чирик Гейтса" +
                " в пятом поколении. Недавно хулиганы подбили ему крылышко, поэтому за едой ему придется добираться непростым путём, " +
                "прыгая по различным предметам. Впрочем, ты ему в этом и поможешь. Управление на WASD или стрелочками, прыжок на SPACE. Удачи!";
            AllStop();

        }
        else if (collis.gameObject.name == "bench" & PlayerPrefs.GetInt("_count") == 1)
        {
            _text.text = "А вот и первый подарочек - кастрюлька! А что в ней - неважно, главное, съедобное! " +
                "Еда повышает твою скорость на одну кроличью силу. Обычный воробушек бегает с тройной кроличьей силой. Подбирай скорее!";
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
            _text.text = "Ура, это бассейн с холодным пенным! Напитки повышают высоту твоего прыжка на одну лягушачью силу. " +
                "Обычный воробушек прыгает с четверной лягушачьей силой. Поплавай с удовольствием!";
            AllStop();
        }
        else if (collis.gameObject.name == "wallEarth01" & PlayerPrefs.GetInt("_count") == 4)
        {
            _text.text = "Ого, впереди чекпоинт! Он приведет тебя на следующий уровень! " +
                "На этом мы с тобой не прощаемся ;) Надеюсь, ты поможешь воробушку пройти все испытания, удачи!";
            AllStop();
        }
        else if (collis.gameObject.name == "diceA" & PlayerPrefs.GetInt("_count") == 5)
        {
            _text.text = "Осторожно, впереди тонкая платформа, а прямо за ней есть она головоломка. " +
                "Я думаю, ты и без меня поймешь, что делать. Найди способ перебраться на ту сторону как можно безопаснее!";
            AllStop();
        }
        else if (collis.gameObject.name == "suitCase" & PlayerPrefs.GetInt("_count") == 6)
        {
            _text.text = "Впереди опять опасное препятстиве, и снова головоломка. Но тут я " +
                "тебе подскажу: за вход нужно заплатить. Хотя бы одной монеткой. Наверное, ямка перед решёткой и будет кассой. " +
                "Попробуй оплатить проход!";
            AllStop();
        }
        else if (collis.gameObject.name == "woodenStart" & PlayerPrefs.GetInt("_count") == 7)
        {
            _text.text = "Здесь я тебя оставлю. Ты знаешь всё, что нужно для выживания здесь. Скоро у воробушка заживёт крылышко и он сможет полететь сам. Помоги ему в последний раз, хорошо?";
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
                if (_uiController.CheckLvl() > 0) { }
                else
                    _uiController.AddLevel();
            }
            else
            {
                _image.color = new Color(255, 0, 0);
                StartCoroutine(Timer());
            }
        }
        else if (collid.gameObject.name == "flag1")
        {
            if (_uiController.CheckKey())
            {
                _movement.enabled = false;
                _animator.SetInteger("state", 3);
                _panelWin.SetActive(true);
                if (_uiController.CheckLvl() == 1)
                    _uiController.AddLevel();
            }
            else
            {
                _image.color = new Color(255, 0, 0);
                StartCoroutine(Timer());
            }
        }
        else if (collid.gameObject.name == "flag2")
        {
            if (_uiController.CheckKey())
            {
                _movement.enabled = false;
                _animator.SetInteger("state", 3);
                _panelWin.SetActive(true);
            }
            else
            {
                _image.color = new Color(255, 0, 0);
                StartCoroutine(Timer());
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

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        _image.color = new Color(0, 0, 0);
    }
}
