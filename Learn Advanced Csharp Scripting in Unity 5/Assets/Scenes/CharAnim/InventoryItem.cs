using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    public enum ITEMTYPE {SPHERE, BOX, CYLINDER};
    public ITEMTYPE type;
    public Sprite GUI_Icon = null;

    void OnTriggerEnter(Collider target) {

        if(!target.CompareTag("Player")) {
            return;
        }

        
    }
}
