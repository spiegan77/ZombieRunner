using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoints = 100f;

    public void TakeDamage(float damage)
    {
        playerHitPoints -= damage;
        if(playerHitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("Player has ceased to play.");
        }
    }
}
