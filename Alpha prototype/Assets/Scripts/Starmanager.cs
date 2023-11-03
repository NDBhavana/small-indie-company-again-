using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
            
        }
        catch
        {
            Star_UI = null;
        }
    }

    // Update is called once per frame
    void Update()
    { starstring = star.ToString() + "/" + reqstar.ToString()+" Stars";
        if (Star_UI != null)
        {
            Star_UI.GetComponent<TMP_Text>().SetText(starstring);

        }
        if (star>=reqstar)
        {
             door.GetComponent<DoorOpening>().CallOpen();
        }
        
    }
}
