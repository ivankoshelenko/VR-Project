using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damage = 5;
    public float cooldownTime = 0.5f;
    public bool isOnCooldown = false;

    private float _timer = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHealthController>(out var player))
        {
            if (!isOnCooldown)
            {
                isOnCooldown = true;
                player.GetDamage(damage);
            }
        }
    }
    private void Update()
    {
        if (isOnCooldown)
        {
            _timer += Time.deltaTime;
            if (_timer > cooldownTime)
            {
                isOnCooldown = false;
            }
        }
    }
}
