using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class SiloDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject leftDoor;
    [SerializeField]
    private GameObject RightDoor;

    public NavMeshSurface navMeshSurface;
    private bool isOpen;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (leftDoor.transform.position.z >= -27.71f)
            {
                leftDoor.transform.position += new Vector3(0, 0, -0.03f);
                RightDoor.transform.position += new Vector3(0, 0, 0.03f);
            }
            else 
            {
                navMeshSurface.BuildNavMesh();
                gameObject.SetActive(false);
            }

        }
    }
    public void GoddamnitOpenTheSiloDoor()
    {
        isOpen = true;
    }
}
