using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    private int lvl;

    private void Start()
    {
        lvl = PlayerPrefs.GetInt("level", 1);
        SceneManager.LoadScene(lvl);
    }
}