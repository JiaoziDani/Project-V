using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //static float Health;
    static float MaxHealth = 1000;

    public Slider HealthBar;
    public GameObject player;

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = MaxHealth;
        //Health = MaxHealth;
    }

    private void Update()
    {
        HealthBar.value = player.GetComponent<PlayerHealth>().GetHealth();
    }

}
