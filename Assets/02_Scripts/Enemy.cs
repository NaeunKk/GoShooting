using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] int scorePoint = 100;
    [SerializeField] GameObject explosion;
    PlayerController playerController;
    ObjectPooler enemyPooler;

    private void Awake()
    {
        enemyPooler = GameObject.Find("EnemySpwaner").GetComponent<ObjectPooler>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(1);
            Destroy(gameObject);
            Die();
        }
    }

    public void Die()
    {
        playerController.Score += scorePoint;
        GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        enemyPooler.ReturnObj(gameObject);
        Destroy(clone.gameObject, 1);
    }
}
