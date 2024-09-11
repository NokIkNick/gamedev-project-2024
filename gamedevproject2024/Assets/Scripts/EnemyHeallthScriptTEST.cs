using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

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
        Destroy(gameObject);
    }

     private void OnTriggerEnter2D(Collider2D collison){
        Debug.Log("Hit Something");
        //int damageAmount = collison.GetComponent<PlayerAttack>().GetAttackDamage();
        int damageAmount = collison.transform.parent.GetComponent<PlayerAttack>().GetAttackDamage();
        Debug.Log("Damage Amount: " + damageAmount);
        TakeDamage(damageAmount);
    }
}

