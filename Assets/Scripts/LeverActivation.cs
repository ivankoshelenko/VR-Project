using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{
    // Start is called before the first frame update
    public Turn_Move fan;
    public GameObject[] windows;
    public GameObject window1;
    public NavMeshSurface navMeshSurface;
    private bool isActivated;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lever"))
        {
            Debug.Log("collided");
            ActivateFan();
            if (isActivated)
            {
                Invoke(nameof(DeactivateFan), 5f);
            }
        }
    }
    public void ActivateFan()
    {
        isActivated = true;
        fan.World = true;
    }
    public void DeactivateFan()
    {
        Debug.Log("deactivated");
        window1.gameObject.SetActive(false);
        foreach (GameObject window in windows)
        {
            window.SetActive(false);
        }
        fan.World = false;
        navMeshSurface.BuildNavMesh();
        gameObject.SetActive(false);
    }
}
