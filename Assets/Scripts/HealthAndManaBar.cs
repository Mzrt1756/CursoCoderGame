using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthAndManaBar : MonoBehaviour
{
    [SerializeField] private MainCharacterData rebeccaData;
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
        healthSlider.maxValue = rebeccaData._maxHealth;
        healthSlider.value = rebeccaData._maxHealth;
    }
    public void SetMaxMana()
    {
        manaSlider.maxValue = rebeccaData._maxMana;
        manaSlider.value = rebeccaData._maxMana;
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
