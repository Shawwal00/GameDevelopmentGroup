using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    private float CurrentHealth;

    public Player_Health_Bar HealthBar;
    private void Start()
    {
        CurrentHealth = MaxHealth;

        HealthBar.SetSliderMax(MaxHealth);
    }

    public void TakeDamage(float amount) 
    {
        CurrentHealth -= amount;
        HealthBar.SetSlider(CurrentHealth);
    }

}
