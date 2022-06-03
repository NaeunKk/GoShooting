using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float attackRate = 0.1f;
    ObjectPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    IEnumerator TryAttack()
    {
        while (true)
        {
            pooler.SpawnObject(transform.position, Quaternion.identity);
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(attackRate);
        }
    }
}
