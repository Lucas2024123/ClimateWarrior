using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBullet : MonoBehaviour
{
    public float m_timeForSelfDestruction;

    private void OnEnable()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(m_timeForSelfDestruction);
        BulletFactory.Instance.CollectBullet(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        BulletFactory.Instance.CollectBullet(gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemySpawn.Instance.KillEnemy();
            Destroy(other.gameObject);
            EnemyMarker.updateRequest+=1;
            if (BarTimer.timeElapsed<=5)
            {
                BarTimer.timeElapsed=0;
            }
            else{
                BarTimer.timeElapsed-=5;
            }
        }
    }
}
