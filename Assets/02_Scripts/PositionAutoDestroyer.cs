using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] StageData sd;
    float destroyWeight = 2f;
    ObjectPooler pooler;
    ObjectPooler enemyPooler;

    private void Start()
    {
        pooler = GameObject.Find("Player").GetComponent<ObjectPooler>();
        enemyPooler = GameObject.Find("EnemySpwaner").GetComponent<ObjectPooler>();
    }

    private void LateUpdate()
    {
        if (transform.position.x > sd.LimitMax.x + destroyWeight ||
            transform.position.x < sd.LimitMin.x - destroyWeight ||
            transform.position.y > sd.LimitMax.y + destroyWeight ||
            transform.position.y < sd.LimitMin.y - destroyWeight)
        {
            if (gameObject.tag == "Bullet")
            {
                pooler.ReturnObj(gameObject);
            }
            else if(gameObject.tag == "Enemy")
            {
                enemyPooler.ReturnObj(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}
