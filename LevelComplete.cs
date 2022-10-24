using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public string nameLevel; 
    
    void Update()
    {
        Invoke("EndTransition", 30f);
    }

    void EndTransition()
    {
        SceneManager.LoadScene(nameLevel);
    }
}
