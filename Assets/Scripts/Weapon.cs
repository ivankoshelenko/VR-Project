using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Text AmmoDisplay;
    [SerializeField]
    private XRSocketInteractor magSocket;
    private Magazine magazine;
    public int ammoCount = 10;
    void Start()
    {
        AmmoDisplay.text = ammoCount.ToString();
    }
    public void TrackAmmo()
    {
        AmmoDisplay.text = ammoCount.ToString();
    }
    public void InsertMagazine()
    {
        magazine = magSocket.GetOldestInteractableSelected().transform.gameObject.GetComponent<Magazine>();
        Debug.Log(magazine.maxBullets.ToString());
        ammoCount += magazine.currentBullets;
        TrackAmmo();
        magazine.gameObject.SetActive(false);
    }
}
