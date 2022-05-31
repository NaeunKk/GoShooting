using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Meteo"))
        {
            Destroy(gameObject);
        }
    }
}
