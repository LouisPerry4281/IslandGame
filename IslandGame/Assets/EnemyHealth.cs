using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health > 0)
        {
            HitFeedback();
            return;
        }

        else
        {
            Destroy(gameObject);
            //Death Sequence (Maybe a coroutine)
        }
    }

    private void HitFeedback()
    {
        
    }
}
