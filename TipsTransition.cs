using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTransition : MonoBehaviour
{
    public GameObject leftHand,
                      rightHand,
                      generalCanvas,
                      spawController;
    
    void Start()
    {
        Invoke("HideTips", 5f);
        Invoke("BeginLevel", 6f);
    }

    
    void BeginLevel()
    {
        leftHand.SetActive(true);
        rightHand.SetActive(true);
        generalCanvas.SetActive(true);
        spawController.SetActive(true);
        
    }

    void HideTips()
    {
        gameObject.SetActive(false);
    }
}
