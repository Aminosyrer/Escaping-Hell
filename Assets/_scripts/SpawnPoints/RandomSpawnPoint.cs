using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ObjectsToSpawn;
    [SerializeField]
    public int ChanceToBeEmpty;
    // Start is called before the first frame update
    void Start()
    {
        if(ChanceToBeEmpty < Random.value * 100)
        {
            int x = Mathf.RoundToInt(Random.value * (ObjectsToSpawn.Count - 1));
            Instantiate(ObjectsToSpawn[x], transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
