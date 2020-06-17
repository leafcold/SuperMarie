using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFire());
    }


    void Update()
    {

    }


   public GameObject[] fireAarray;
    IEnumerator SpawnFire()
    {
        do
        {
            Instantiate(fireAarray[Random.Range(0,2)],
                        transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(1.5f, 5));
        } while (Player.isDie != true);

    }
}
