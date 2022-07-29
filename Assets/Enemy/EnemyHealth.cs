using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoint = 0;
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }
    
    private void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        currentHitPoint--;
        if(currentHitPoint <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
        }
    }
}
