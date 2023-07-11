using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            PlayerDeath();
        }

        else
            PlayerHit();
    }

    private void PlayerHit()
    {
        throw new NotImplementedException();
    }

    private void PlayerDeath()
    {
        throw new NotImplementedException();
    }
}
