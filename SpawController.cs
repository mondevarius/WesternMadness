using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    
    public GameObject[] spawBandit1,
                        spawBandit2,
                        spawBandit3;

    public Transform[] pointsBandits1,
                       pointsBandits2,
                       pointsBandits3;

    private int prefab1,
                prefab2,
                prefab3;

    private int pointsInstantiate1,
                pointsInstantiate2,
                pointsInstantiate3;

    private int timeSpaw;
    
    public int timeSpawMin,
               timeSpawMax;


    void Start()
    {
        StartCoroutine(InstantiateBandit());

    }

    void Update()
    {
        Spaw();

    }

    void Spaw()
    {
        prefab1 = Random.Range(0, 4);
        prefab2 = Random.Range(0, 4);
        prefab3 = Random.Range(0, 4);

        pointsInstantiate1 = Random.Range(0, pointsBandits1.Length);
        pointsInstantiate2 = Random.Range(0, pointsBandits2.Length);
        pointsInstantiate3 = Random.Range(0, pointsBandits3.Length);

        timeSpaw = Random.Range(timeSpawMin, timeSpawMax);

    }

    IEnumerator InstantiateBandit()
    {

        while (true)
        {
            yield return new WaitForSecondsRealtime(timeSpaw);
            Instantiate(spawBandit1[prefab1], pointsBandits1[pointsInstantiate1].transform.position, pointsBandits1[pointsInstantiate1].transform.rotation);

            yield return new WaitForSecondsRealtime(timeSpaw);
            Instantiate(spawBandit2[prefab2], pointsBandits2[pointsInstantiate2].transform.position, pointsBandits1[pointsInstantiate2].transform.rotation);
            
            yield return new WaitForSecondsRealtime(timeSpaw);
            Instantiate(spawBandit3[prefab3], pointsBandits3[pointsInstantiate3].transform.position, pointsBandits1[pointsInstantiate3].transform.rotation);

        }


    }
}
