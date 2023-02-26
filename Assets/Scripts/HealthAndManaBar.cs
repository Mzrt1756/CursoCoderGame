using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthAndManaBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
        SetMaxMana();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
        SetMana();
    }
    public void SetMaxHealth()
    {
        healthSlider.maxValue = GameManager.instance._maxHealth;
        healthSlider.value = GameManager.instance._maxHealth;
    }
    public void SetMaxMana()
    {
        manaSlider.maxValue = GameManager.instance._maxMana;
        manaSlider.value = GameManager.instance._maxMana;
    }
    public void SetHealth()
    {
        healthSlider.value = GameManager.instance._remainingHealth; 
    }

    public void SetMana()
    {
        manaSlider.value = GameManager.instance._remainingMana;
    }
}
