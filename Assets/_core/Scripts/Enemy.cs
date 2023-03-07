using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int damagePerHit = 10;
    [SerializeField] int enemyHealth = 30;
    ScoreBoard scoreBoard;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();   
        
    }
    
    void ProcessHit(){
        GameObject hitVfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitVfx.transform.parent = parent;
        scoreBoard.IncreaseScore(scorePerHit);
        enemyHealth -= damagePerHit;
        if (enemyHealth < 1)
        {
            KillEnemy();
        }
    }
    
    void KillEnemy(){
        GameObject deathVfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        deathVfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
