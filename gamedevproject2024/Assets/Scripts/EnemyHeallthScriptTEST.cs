using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int health = 1;

    public event Action<GameObject> onDeath;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Enemy took " + damageAmount + " damage. Remaining Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        onDeath?.Invoke(gameObject);
        Destroy(gameObject, 0.5f);
    }

     private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Hit Something");
        if (collision.CompareTag("PlayerAttackHitbox"))
        {
         //int damageAmount = collison.GetComponent<PlayerAttack>().GetAttackDamage();
        int damageAmount = collision.transform.parent.GetComponent<PlayerAttack>().GetAttackDamage();
        Debug.Log("Damage Amount: " + damageAmount);
        TakeDamage(damageAmount);
        }

    }
}

