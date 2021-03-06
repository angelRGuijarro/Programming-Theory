using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance { get; private set; }

    public static string playersName { get; private set; }
    
    public string dextrous_lefty = "dextrous";

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {            
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setPlayersName(string name)
    {
        playersName = name;                    
    }
}
