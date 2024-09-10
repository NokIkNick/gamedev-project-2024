using Unity.VisualScripting;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float jumpForce;
    public LayerMask obstacleLayer;
    private float distance;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,speed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if (player.transform.position.y > transform.position.y)
        {
            Jump();
        }

    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    


}
