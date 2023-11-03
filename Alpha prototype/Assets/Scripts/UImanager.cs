using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    public GameObject Tutorial;
    //public Button pause,resume;
    // Start is called before the first frame update
    void Start()
    {
       
      
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
       }

    
   public void Resume()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Tutorial.SetActive(true);
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Tutorial.SetActive(false);
    }
}
