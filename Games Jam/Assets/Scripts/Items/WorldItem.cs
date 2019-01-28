using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{

    [SerializeField]
    private ItemDefinition definition;

    public void OnEnable()
    {
        /*
         * When the object is enabled, set the item's sprite renderer to the item's sprite 
         */
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = definition.itemSprite;
    }
}
