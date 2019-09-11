using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharController : MonoBehaviour
{

    private Animator thisAnimator = null;
    private int vertHash = Animator.StringToHash("Vertical");
    private int horzHash = Animator.StringToHash("Horizontal");
    

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        thisAnimator.SetFloat(horzHash, horz, 0.1f, Time.deltaTime);
        thisAnimator.SetFloat(vertHash, vert, 0.1f, Time.deltaTime);
    }
}
