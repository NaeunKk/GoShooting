using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] int scorePoint = 100;
    [SerializeField] GameObject explosion;
    PlayerController playerController;

    private void Awake()
    {
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
        explosion = Instantiate(explosion);
        playerController.Score += scorePoint;
        Destroy(gameObject);
        Destroy(explosion);
    }
}
