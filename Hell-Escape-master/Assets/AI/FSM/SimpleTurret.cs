using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleTurret : MonoBehaviour
{
    [SerializeField]
    private float turnRateRadians = 2 * Mathf.PI;

    [SerializeField]
    private Transform turretTop; // the gun part that rotates

    [SerializeField]
    private Transform bulletSpawnPoint;

    private GameObject target;

    void Update()
    {
        TargetEnemy();
    }

    void TargetEnemy()
    {
          target = GetClosestEnemy();

        if (target != null)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            
            targetDir.y = 0.0f;
            targetDir = targetDir.normalized;

            Vector3 currentDir = turretTop.forward;

            currentDir = Vector3.RotateTowards(currentDir, targetDir, turnRateRadians * Time.deltaTime, 1.0f);

            Quaternion qDir = new Quaternion();
            qDir.SetLookRotation(currentDir, Vector3.up);
            turretTop.rotation = qDir;
        }
    }
    GameObject GetClosestEnemy()
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
            return player;
    }

}

