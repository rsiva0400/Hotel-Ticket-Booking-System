using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.QuickStart;

public class GamePopUpConfig : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rpmcontroller; 
    ThirdPersonMovement controller; 

    private void OnEnable() {
        controller = rpmcontroller.GetComponent<ThirdPersonMovement>();

        controller.walkSpeed = 6f;
        controller.runSpeed = 16f;
    }

}
