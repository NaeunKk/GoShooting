using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField] PlayerHP playerHP;
    private Slider sliderHP;

    void Start()
    {
        sliderHP = GetComponent<Slider>();
    }

    void Update()
    {
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
