using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class FinishGame : MonoBehaviour
{
    public XRSocketInteractor gemSocket;
    public void Restart()
    {
        if(gemSocket.GetOldestInteractableSelected().transform.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Finish");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
