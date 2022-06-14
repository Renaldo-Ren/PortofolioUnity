using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private void Awake (){
        bar = transform.Find("Health Fill");
    }

    public void SetSize(float sizeNormalized){
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    // public Slider slider;

    // public void SetMaxHealth(int health)
    // {
    //     slider.maxValue = health;
    //     slider.value = health;
    // }

    // public void SetHealth(int health)
    // {
    //     slider.value = health;
    // }
}
