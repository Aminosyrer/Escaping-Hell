using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/Droptable")]
public class DroptableDataSO : ScriptableObject
{
    //May god forgive me for what i am about to do
    [Serializable]
    public struct Item
    {
        public GameObject go;
        public int Weight;
    }

    public List<Item> Items;
    [Range(0, 99)]
    public int ChanceForExtraDrops;
    [NonSerialized]
    public List<GameObject> droptable = new();

    public void BuildDropTable()
    {
        //stops every chest and their mother from building the droptable
        if (droptable.Count > 0) return;
        Debug.Log("Building Droptable");
        droptable = new List<GameObject>();
        foreach(var item in Items)
        {
            for(int i = 0; i < item.Weight; i++)
            {
                droptable.Add(item.go);
            }
        }
    }
}
