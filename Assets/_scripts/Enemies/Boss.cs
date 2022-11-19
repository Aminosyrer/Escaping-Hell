using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Exit;

    public void SpawnExit()
    {
        Instantiate(Exit, transform.position, transform.rotation);
    }
}
