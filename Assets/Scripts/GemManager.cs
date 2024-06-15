using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemManager : MonoBehaviour
{
    [SerializeField] private int numberOfGems;
    private int numberOfGemsInSocket;
    // Start is called before the first frame update
    public UnityEvent unlock;
    public void AddGem()
    {
        numberOfGemsInSocket++;
        CheckForAllGems();
    }
    public void CheckForAllGems()
    {
        if (numberOfGemsInSocket >= numberOfGems)
        {
            RemoveGems();
            unlock.Invoke();
        }
    }
    public void RemoveGems()
    {
        numberOfGemsInSocket--;
    }
}
