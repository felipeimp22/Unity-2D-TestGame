using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyBehaviour : MonoBehaviour
{
    // // Start is called before the first frame update
    public float hitPoints;
    public float maxHitPoints = 5;
    public healthBarBehaviour healthbar;
    void Start()
    {
        hitPoints = maxHitPoints;
        healthbar.SetHealth(hitPoints, maxHitPoints);
    }

    public void takeHit(float damage)
    {
        hitPoints -= damage;
        healthbar.SetHealth(hitPoints, maxHitPoints);
        if(hitPoints<=0){
            Destroy(gameObject);
        }
    }
}
