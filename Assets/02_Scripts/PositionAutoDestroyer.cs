using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] StageData sd;
    float destroyWeight = 2f;

    private void LateUpdate()
    {
        if (transform.position.x > sd.LimitMax.x + destroyWeight || transform.position.x < sd.LimitMin.x - destroyWeight ||
            transform.position.y > sd.LimitMax.y + destroyWeight || transform.position.y < sd.LimitMin.y - destroyWeight)
        {
            Destroy(gameObject);
        }
    }
}
