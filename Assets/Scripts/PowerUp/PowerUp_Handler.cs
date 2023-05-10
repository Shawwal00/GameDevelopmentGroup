using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerUp_Handler : MonoBehaviour
{
    [HideInInspector] public bool hasDoubleJumpBeenActivated = false;
    [HideInInspector] public bool hasSpeedBoostBeenActivated = false;
    [HideInInspector] public bool hasSlowTrapBeenActivated = false;
    private bool hasBeenSped = false;
    private bool hasBeenSlowed = false;
    [HideInInspector] public float double_jump_timer = 0;
    [HideInInspector] public float speed_boost_timer = 0;
    [HideInInspector] public float slow_timer = 0;
    [HideInInspector] public float double_jump_max_time = 10f;
    [HideInInspector] public float speed_boost_max_time = 10f;
    [HideInInspector] public float slow_max_time = 10f;
    private BetterPlayerMovement player;
    private float standard_movement_speed;
    private int standard_max_jumps;
    public TextMeshProUGUI double_jump_text;
    public TextMeshProUGUI speed_boost_text;
    public GameObject speed_boost_indicator;
    public GameObject double_jump_indicator;

    void Awake()
    {
        player = this.gameObject.GetComponent<BetterPlayerMovement>();
        standard_movement_speed = player.speed;
        standard_max_jumps = player.jumpMax;
        double_jump_indicator.SetActive(false);
        speed_boost_indicator.SetActive(false);
    }

    void FixedUpdate()
    {
        if (hasDoubleJumpBeenActivated)
        {
            double_jump_indicator.SetActive(true);
            double_jump_indicator.GetComponent<PowerUp_UI>().UpdateFill(double_jump_timer, double_jump_max_time);
            player.jumpMax = 2;
            double_jump_text.text = "Double Jump \n" + ((int)double_jump_timer).ToString() + "/" + double_jump_max_time;
            double_jump_timer += Time.deltaTime;
            //Debug.Log(timer);
            if (double_jump_timer >= double_jump_max_time)
            {
                double_jump_indicator.SetActive(false);
                double_jump_text.text = "";
                player.jumpMax = standard_max_jumps;
                hasDoubleJumpBeenActivated = false;
                double_jump_timer = 0;
            }
        }

        if (hasSpeedBoostBeenActivated)
        {
            speed_boost_indicator.SetActive(true);
            speed_boost_indicator.GetComponent<PowerUp_UI>().UpdateFill(speed_boost_timer, speed_boost_max_time);
            if (!hasBeenSped)
            {
                player.speed = player.speed + 20;
                hasBeenSped = true;
            }
            speed_boost_text.text = "Speed Boost \n" + ((int)speed_boost_timer).ToString() + "/" + speed_boost_max_time;
            speed_boost_timer += Time.deltaTime;
            //Debug.Log(timer);
            if (speed_boost_timer >= speed_boost_max_time)
            {
                speed_boost_indicator.SetActive(false);
                speed_boost_text.text = "";
                player.speed = standard_movement_speed;
                hasSpeedBoostBeenActivated = false;
                hasBeenSped = false;
                speed_boost_timer = 0;
            }
        }

        if (hasSlowTrapBeenActivated)
        {
            //slow_indicator.SetActive(true);
            //slow_indicator.GetComponent<PowerUp_UI>().UpdateFill(slow_timer, slow_max_time);
            if (!hasBeenSlowed)
            {
                player.speed = player.speed - 5;
                hasBeenSlowed = true;
            }
            //slow_text.text = "Speed Boost \n" + ((int)slow_timer).ToString() + "/" + speed_boost__max_time;
            slow_timer += Time.deltaTime;
            //Debug.Log(timer);
            if (slow_timer >= slow_max_time)
            {
                //slow_indicator.SetActive(false);
                //slow_text.text = "";
                player.speed = player.speed + 5;
                hasSlowTrapBeenActivated = false;
                hasBeenSlowed = false;
                slow_timer = 0;
            }
        }
    }
}
