using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    playerHealth playerHealth;      // Reference to the player's health.
    enemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = GetComponent<enemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }

}