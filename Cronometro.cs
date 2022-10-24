using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronometro : MonoBehaviour
{
    private float timeBandit;
    
    public float seconds;
    
    public static bool stopCount = false;
    
    public Text countDown;

    private GameObject spawController,
                       leftHand,
                       rightHand;
    

    void Start()
    {
        spawController = GameObject.FindGameObjectWithTag("SpawController");
        rightHand = GameObject.FindGameObjectWithTag("RightHand");
        leftHand = GameObject.FindGameObjectWithTag("LeftHand");
        timeBandit = Random.Range(3, 5);  
    }

    void Update()
    {
        countDown.text = seconds.ToString("0");

    }

    void FixedUpdate()
    {

        CountSeconds();
        StopCount();
            
    }

    void CountSeconds()
    {
        if(stopCount == false && timeBandit > 0)
        {
            seconds = timeBandit -= Time.deltaTime;
        }
        if(timeBandit < 0)
        {
            seconds = 0;
        }
       
    }

    
    void StopCount()
    {
        if (seconds <= 0)
        {
            stopCount = true;
            Destroy(spawController.gameObject);
            Destroy(rightHand.gameObject);
            Destroy(leftHand.gameObject);
            for (int x = 0; x < RightHand.orangeBandits.Length; x++)
            {
                RightHand.orangeBandits[x] = null;

            }
            for (int x = 0; x < RightHand.redBandits.Length; x++)
            {
                RightHand.redBandits[x] = null;

            }
            for (int x = 0; x < LeftHand.blueBandits.Length; x++)
            {
                LeftHand.blueBandits[x] = null;

            }
            for (int x = 0; x < LeftHand.purpleBandits.Length; x++)
            {
                LeftHand.purpleBandits[x] = null;

            }
        }
    }
}
