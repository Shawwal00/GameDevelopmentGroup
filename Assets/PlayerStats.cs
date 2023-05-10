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

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            transform.position = new Vector3(0, 10, 0);
            CurrentHealth = 100;
            HealthBar.SetSlider(CurrentHealth);
        }

        if(transform.position.y < -10) 
        {
            CurrentHealth = 0;
        }
    }

    public void TakeDamage(float amount) 
    {
        CurrentHealth -= amount;
        HealthBar.SetSlider(CurrentHealth);
    }

}
