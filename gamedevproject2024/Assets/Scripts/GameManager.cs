using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int killCount;
    [SerializeField] private float initialSpawnTimer = 10f;
    private GameObject player;
    private event Action endGame;
    [SerializeField] private Difficulty currentDifficulty;
    [SerializeField] private float spawnTimer;
    
    private enum Difficulty{
        EASY,
        MEDIUM,
        HARD
    }
    
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<IPlayer>().onDeath += HandlePlayerDeath;
    }
    
    void Start()
    {
        player.transform.position = playerSpawnPoint.position;
        currentDifficulty = Difficulty.EASY;
        spawnTimer = initialSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(killCount >= 50 && killCount < 100){
            currentDifficulty = Difficulty.MEDIUM;
        }else if(killCount >= 100){
            currentDifficulty = Difficulty.HARD;
        }

        if(spawnTimer <= 0){
            if((int)currentDifficulty == 0)
                spawnTimer = initialSpawnTimer;
            else {
                spawnTimer = initialSpawnTimer / (int)currentDifficulty + 1f; 
            }
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy(){
        GameObject enemyObject = Instantiate(enemyPrefab, 
        new Vector3(UnityEngine.Random.Range(-10, 10), 0, 
        UnityEngine.Random.Range(-10, 10)), Quaternion.identity);

        IEnemy enemy = enemyObject.GetComponent<IEnemy>();
        
        if(enemy != null){
            enemy.onDeath += HandleEnemyDeath;
        }
        yield return new WaitForSeconds(1f);
    }

    void HandlePlayerDeath(){
        Debug.Log("Player died");
        endGame?.Invoke();
    }

    void HandleEnemyDeath(GameObject enemy){
        Debug.Log("Enemy died");
        killCount++;
        enemy.GetComponent<IEnemy>().onDeath -= HandleEnemyDeath;
        Destroy(enemy, 1f);
    }
}
