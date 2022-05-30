using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField] float scrollerRange = 10f;
    [SerializeField] Transform target;

    void Update()
    {
           if(transform.position.y <= -scrollerRange)
        {
            transform.position = target.position + Vector3.up * scrollerRange;
        }
    }
}
