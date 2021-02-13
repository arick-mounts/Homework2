using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class GameController : MonoBehaviour
{


    public GameObject paused;
    private bool pauseBool = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (paused != null)
        {
            if (Input.GetKeyDown("escape"))
            {
                Debug.Log("esc pressed");
                if (pauseBool == false)
                {
                    Debug.Log("game paused");
                    Time.timeScale = 0;
                    paused.SetActive(true);
                    pauseBool = true;
                }
                else if (pauseBool == true)
                {
                    Debug.Log("game unpaused");
                    Time.timeScale = 1;
                    paused.SetActive(false);
                    pauseBool = false;
                }
            }
        }
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void endGame()
    {
        Debug.Log("Game has been ended");
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else

        Application.Quit();
        #endif
    }
}
