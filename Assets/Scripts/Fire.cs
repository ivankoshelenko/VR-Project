using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    public float speed = 50f;
    public GameObject bulletPrefab;
    public Transform barrel;
    public static event Action fireBullet;
    [SerializeField]
    private Weapon weapon;
    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    public void FireBullet()
    {
        weapon.TrackAmmo();
        if (weapon.ammoCount >0)
        {
            weapon.ammoCount--;
            GameObject createBullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            createBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            Destroy(createBullet, 3f);     
        }

        //fireBullet.Invoke();
    }
}
