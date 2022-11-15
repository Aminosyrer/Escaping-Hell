using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public EnemyDropTable dropTable;

    public void Awake()
    {
        dropTable.BuildDropTable();
    }

    public void DropItem()
    {
        if(dropTable.ChanceForDrop > Random.Range(0, 101))
        {
            do
            {
                int x = Random.Range(0, dropTable.droptable.Count);
                Instantiate(dropTable.droptable[x], transform.position, transform.rotation);
            } while (dropTable.ChanceForExtraDrops > Random.Range(0, 101));
        }
    }
}
