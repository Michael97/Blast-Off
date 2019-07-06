using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItemData : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        item.isOwned = PlayerPrefsX.GetBool(item.name, false);
    }
}
