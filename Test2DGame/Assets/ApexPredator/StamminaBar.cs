using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamminaBar : MonoBehaviour
{
    public Stamina stamina;
    private Image barImage;
    

    public void Awake(){
        barImage = transform.Find("Stamina Fill").GetComponent<Image>();
        stamina = new Stamina();
        
    }

    private void Update(){
        stamina.Update();
        barImage.fillAmount = stamina.GetStaminaNormalized();
        
    }
}

public class Stamina {
    public const int STAMINA_MAX = 100;

    public float staminaAmount;
    private float staminaRegenAmount;
    public bool isUsed;
    public Stamina(){
        staminaAmount = 0;
        staminaRegenAmount = 30f;
    }

    public void Update(){
        if (Input.GetMouseButtonDown(1))
        {
            isUsed = true;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            isUsed = false;
        }
        if(!isUsed){
            staminaAmount += staminaRegenAmount * Time.deltaTime;
            staminaAmount = Mathf.Clamp(staminaAmount, 0f, STAMINA_MAX);
        }
        else{
            staminaAmount -= 0.05f;
            staminaAmount = Mathf.Clamp(staminaAmount, 0f, STAMINA_MAX);
        }
        
    }

    public void SpendStamina(int amount) {
        if(staminaAmount >= amount){
            staminaAmount -= amount;
        }
    }

    public float GetStaminaNormalized(){
        return staminaAmount / STAMINA_MAX;
    }
}