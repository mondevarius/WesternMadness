using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongColor : MonoBehaviour
{
    public GameObject spawController,
                      leftHand,
                      rightHand,
                      canvasWrongColor;

    public AudioSource levelFail;

    private bool stopSFX = true;

    
    void Update()
    {
        ActiveGameOver();
    }

    void ActiveGameOver()
    {
        if (LeftHand.wrongColorActive || RightHand.wrongColorActive)
        {
            canvasWrongColor.SetActive(true);
            if (stopSFX)
            {
                levelFail.PlayOneShot(levelFail.clip);
                stopSFX = false;
            }
            Destroy(spawController.gameObject);
            Destroy(rightHand.gameObject);
            Destroy(leftHand.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Orange"));
            Destroy(GameObject.FindGameObjectWithTag("Red"));
            Destroy(GameObject.FindGameObjectWithTag("Blue"));
            Destroy(GameObject.FindGameObjectWithTag("Purple"));

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
