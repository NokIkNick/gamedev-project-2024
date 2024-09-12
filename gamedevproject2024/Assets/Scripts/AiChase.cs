using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float jumpForce;
    public LayerMask obstacleLayer;
   // private float distance;
    private Rigidbody2D rb;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
     //   distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

        //transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,speed*Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 currentDirection = Vector2.Lerp(transform.position, direction, Time.deltaTime * 40f);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        RaycastHit2D hitter = Physics2D.Raycast(transform.position, Vector2.right);
        if (hitter.collider != null) 
        {
            
        }
        if (player.transform.position.y > transform.position.y)
        {
            //Jump();
        }

    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    


}
