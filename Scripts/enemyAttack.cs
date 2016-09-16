using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    public float damageTime = 0.3f;

    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    playerHealth playerHealth;                  // Reference to the player's health.
    enemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    int randomAttack;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = GetComponent<enemyHealth>();
        anim = GetComponent<Animator>();
        randomAttack = Random.Range(0, 2);
    }

   

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
       
        
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;
        randomAttack = Random.Range(0, 2);
        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            
            if(randomAttack == 0)
            {
            anim.SetTrigger("attack1");
                
            Invoke("PlayerTakeDamage", damageTime);
            }
            else if(randomAttack == 1)
            {
            anim.SetTrigger("attack2");
               
            Invoke("PlayerTakeDamage", damageTime);

            }
        }
    }


    void PlayerTakeDamage()
    {
        playerHealth.TakeDamage(attackDamage);
    }
}
