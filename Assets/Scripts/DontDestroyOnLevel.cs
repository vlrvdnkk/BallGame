using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLevel : MonoBehaviour
{
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main" & SceneManager.GetActiveScene().name == "Levels")
            this.gameObject.GetComponent<AudioSource>().enabled = false;
        else
            this.gameObject.GetComponent<AudioSource>().enabled = true;
        DontDestroyOnLoad(this.gameObject);
    }
}