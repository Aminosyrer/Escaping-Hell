using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class LootChest : MonoBehaviour
{
    public DroptableDataSO DroptableData;

    public BoxCollider2D Collider;

    protected SpriteRenderer _SpriteRenderer;
    public Sprite OpenChest;


    public void Awake()
    {
        Collider = GetComponent<BoxCollider2D>();
        Collider.isTrigger = true;
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        DroptableData.BuildDropTable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        do
        {
            int x = Mathf.FloorToInt(Random.value * DroptableData.droptable.Count);
            //Best way to give a even chance for all entries in the droptable
            if (x == DroptableData.droptable.Count) x = DroptableData.droptable.Count - 1;
            float itemx = transform.position.x + (Random.value * 2 - 1);
            float itemy = transform.position.y + (Random.value * 2 - 1);
            Instantiate(DroptableData.droptable[x], new Vector3(itemx, itemy), transform.rotation);
        }
        while (DroptableData.ChanceForExtraDrops > Random.value * 100);
        _SpriteRenderer.sprite = OpenChest;
        Collider.enabled = false;
    }
}
