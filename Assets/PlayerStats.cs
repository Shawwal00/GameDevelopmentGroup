using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    private float CurrentHealth;
    private GameObject[] platformArray;

    public Player_Health_Bar HealthBar;

    private GameObject jumpPowerUp;
    private GameObject JumpPULocation;
    private bool secondRespawn;
    private void Start()
    {
        
        JumpPULocation = GameObject.Find("JumpLocationPU");
        CurrentHealth = MaxHealth;

        HealthBar.SetSliderMax(MaxHealth);
    }

    private void Update()
    {
        if (transform.position.x < -470)
        {
            secondRespawn = true;
        }

        if (CurrentHealth <= 0)
        {
            
            //restart function
            if (secondRespawn == true)
            {
                transform.position = new Vector3(-466.0f, 121.89f, -1.85f);
            }
            else
            {
                transform.position = new Vector3(0, 10, 0);
            }
            CurrentHealth = 100;
            HealthBar.SetSlider(CurrentHealth);
            
            platformArray = GameObject.FindGameObjectsWithTag("Platform");
            foreach (var platform in platformArray)
            {
                platform.GetComponent<PlatformCreation>().restart = true;
            }
            jumpPowerUp = GameObject.FindWithTag("Double Jump PU");
            Instantiate(jumpPowerUp, JumpPULocation.transform.position, JumpPULocation.transform.rotation);
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
