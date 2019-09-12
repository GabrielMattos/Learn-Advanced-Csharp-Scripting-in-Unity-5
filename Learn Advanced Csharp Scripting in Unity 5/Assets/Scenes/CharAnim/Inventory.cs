using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance {

        get {
            if(thisInstance == null) {
                GameObject inventoryObject = new GameObject("Inventory");
                thisInstance = inventoryObject.AddComponent<Inventory>();
            }

            return thisInstance;
        }
    }

    private static Inventory thisInstance = null;

    public RectTransform itemList = null;

    void Awake() {

        if (thisInstance != null) {
            DestroyImmediate(gameObject);
            return;
        }

        thisInstance = this;
    }

    public static void AddItem(GameObject GO) {

        foreach (Collider C in GO.GetComponents<Collider>()) 
        {
            C.enabled = false;
        }

        foreach (MeshRenderer MR in GO.GetComponents<MeshRenderer>())
        {
            MR.enabled = false;
        }

        for(int i = 0; i < thisInstance.itemList.childCount; i++) {
            Transform item = thisInstance.itemList.GetChild(i);
            if(!item.gameObject.activeSelf) {
                item.GetComponent<SpriteRenderer>().sprite = GO.GetComponent<InventoryItem>().GUI_Icon;
                item.gameObject.SetActive(true);
                return;
            }
        }
    }
}
