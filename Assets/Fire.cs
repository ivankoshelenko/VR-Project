using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    public float speed = 50f;
    public GameObject bulletPrefab;
    public Transform barrel;
    public static event Action fireBullet;

    public void FireBullet()
    {
        GameObject createBullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        createBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        Destroy(createBullet, 5f);
        //fireBullet.Invoke();
    }
}
