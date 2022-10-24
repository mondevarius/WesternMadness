using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBandit : MonoBehaviour
{
    public AudioSource dieSFX;


    public void DieSFX()
    {
        dieSFX.PlayOneShot(dieSFX.clip);
    }
    
    
    public void DestroyBandit()
    {
        Destroy(gameObject);

    }
}
