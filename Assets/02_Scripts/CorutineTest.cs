using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutineTest : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    void Start()
    {
        StartCoroutine(Fire());
        StartCoroutine(Fire_1());
        Debug.Log("코루틴 끝");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Fire_1()
    {
        while (true) {
            Debug.Log("Als");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("B");
        }

    }

    void Update()
    {
        
    }
}
