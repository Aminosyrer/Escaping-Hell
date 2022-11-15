using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/EnemyDroptable")]
public class EnemyDropTable : DroptableDataSO
{
    [Range(0,100)]
    public int ChanceForDrop;
}
