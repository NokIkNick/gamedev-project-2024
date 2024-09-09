using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDeath;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
   
   
    
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
       
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
            OnDeath?.Invoke(this);
        }

    }

}
