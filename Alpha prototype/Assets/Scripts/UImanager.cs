using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    //public Button pause,resume;
    // Start is called before the first frame update
    void Start()
    {
       
      
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
