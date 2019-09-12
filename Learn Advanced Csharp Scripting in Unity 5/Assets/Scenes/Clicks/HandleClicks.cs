using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleClicks : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData) {

        print("You clicked: " + eventData.pointerPress.name);
    }

    public void Test() {

               print("BOTOU");
 
    }
}
