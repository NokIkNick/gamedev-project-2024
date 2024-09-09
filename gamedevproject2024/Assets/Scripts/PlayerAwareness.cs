using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public bool AwareOfPlayer {  get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position; 
        DirectionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance) 
        {
            Debug.Log("I am aware!");
            AwareOfPlayer = true;
        }
        else 
        { 
            AwareOfPlayer= false;
        }
    }
}
