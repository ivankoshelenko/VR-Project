using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthController : MonoBehaviour
{
    public float enemyHealth = 100;

    private void Start()
    {
        //hitSound = GetComponent<AudioSource>();
    }
    private void GetNPCDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            //KillNPC();
            Destroy(gameObject);
            //spawner.SpawnTank();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        if (other.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            GetNPCDamage(bullet.Damage);
            //hitSound.Play();
            Debug.Log("hit");
        }
        if(other.gameObject.CompareTag("Melee"))
        {
            GetNPCDamage(50);
        }
    }
}
