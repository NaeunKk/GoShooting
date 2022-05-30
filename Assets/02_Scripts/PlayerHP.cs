using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float maxHP = 10f;
    [SerializeField] SpriteRenderer sr;
    float currentHP;

    public float MaxHP 
    { 
        get { return maxHP; }
     }
    public float CurrentHP
    {
        get { return currentHP; }
    }

    void Start()
    {
        currentHP = maxHP;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    IEnumerator Hit()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        StopCoroutine(Hit());
        StartCoroutine(Hit());
    }
}
