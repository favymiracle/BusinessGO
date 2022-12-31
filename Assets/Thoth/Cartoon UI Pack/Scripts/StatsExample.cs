using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsExample : MonoBehaviour
{

    //variables

    public float maxHealth;
    public float maxThirst, maxHunger;
    public float thirstInRate, hungerInRate;
    public Slider healthBar;
    public Slider hungerBar;
    public Slider thirstBar;

    public float health, thirst, hunger;
 

    private bool playerDead;

   
    public void Start()
    {
        health = maxHealth;
        thirst = maxThirst;
        hunger = maxHunger;

        // Hunger Bar
        if (hungerBar == null)
        {
            GameObject HB = GameObject.Find("HungerBar");
            if (HB != null)
            {
                hungerBar = HB.GetComponent<Slider>();
            }
        }

        if (hungerBar != null)
        {
            hungerBar.value = maxHunger * 0.01f;
        }

        // Thirst Bar

        if (thirstBar == null)
        {
            GameObject HB = GameObject.Find("Thirst Bar");
            if (HB != null)
            {
                thirstBar = HB.GetComponent<Slider>();
            }
        }

        if (thirstBar != null)
        {
            thirstBar.value = maxThirst * 0.01f;
        }

    }

    // When Die:
    public void Die()
    {
        playerDead = true;
        print("You have died because of thrst or hunger");
    }

    public void Drink(float decreaseRate)
    {
        thirst += decreaseRate;
    }

    public void Update()
    {
        //
        if (!playerDead)
        {
            thirst -= thirstInRate * Time.deltaTime;
            hunger -= hungerInRate * Time.deltaTime;
        }

        if (thirst <= 0)
            Die();
        if (hunger <= 0)
            Die();

        print(thirst);

        if (hungerBar != null)
        {
            hungerBar.value = hunger * 0.01f;
        }

        if (thirstBar != null)
        {
            thirstBar.value = thirst * 0.01f;
        }

    }

}
