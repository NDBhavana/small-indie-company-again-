using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Starmanager : MonoBehaviour
{
    public int star=0;
    public int reqstar=5;
    // Start is called before the first frame update
    public GameObject door;
    public GameObject Star_UI;
    string starstring = "";
    

    void Start()
    {
        star = 0;
        try
        {
            Star_UI = GameObject.Find("Startext");

            if (PlayerPrefs.GetInt("Stars") > 0 && !Transition.IsItNextLevel)
            {
                star = PlayerPrefs.GetInt("Stars");
            }
            else
            {   Transition.IsItNextLevel=false;
                star = 0;
            }
            
        }
        catch
        {
            Star_UI = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {   starstring = star.ToString() + "/" + reqstar.ToString()+" Stars";
        PlayerPrefs.SetInt("Stars",star);

        if (Star_UI != null)
        {
            Star_UI.GetComponent<TMP_Text>().SetText(starstring);
            PlayerPrefs.SetString("Star UI",starstring);

        }
        if (star>=reqstar)
        {
            door.GetComponent<DoorOpening>().CallOpen();
            PlayerPrefs.SetInt("DoorOpened", 1); // Save door status using PlayerPrefs

        }
        
    }

}
