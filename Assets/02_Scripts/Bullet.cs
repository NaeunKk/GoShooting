using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ObjectPooler pooler;

    private void Start()
    {
        pooler = GameObject.Find("Player").GetComponent<ObjectPooler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Die();
            //Destroy(gameObject);
            pooler.ReturnObj(gameObject);
        }
        if (collision.gameObject.CompareTag("Meteo"))
        {
            Destroy(gameObject);
        }
    }
}
