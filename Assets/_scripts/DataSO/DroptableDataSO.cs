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

    public List<GameObject> droptable;

    public void BuildDropTable()
    {
        //stops every chest and their mother from building the droptable
        if (droptable.Count > 0) return;
        droptable = new List<GameObject>();
        Debug.Log("building Droptable");
        foreach(var item in Items)
        {
            Debug.Log("trying to add item");
            for(int i = 0; i < item.Weight; i++)
            {
                Debug.Log("Item added");
                droptable.Add(item.go);
            }
        }
    }
}
