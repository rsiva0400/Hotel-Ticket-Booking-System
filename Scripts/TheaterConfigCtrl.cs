using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.QuickStart;
using UnityEngine.UI;
using UnityEngine.Video;

public class TheaterConfigCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PopUp;
    [HideInInspector]public int config = -1; 
    [HideInInspector]public string AlertTitle = "";
    [HideInInspector]public string AlertMessage = "";
    public GameObject rpmcontroller; 
    public GameObject DirectionalLight1;
    public VideoPlayer VideoController;
    ThirdPersonMovement controller; 
    public Text Title;
    public Text Message;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (config == 0)
        {
            print("Config: "+ config+" Recieved from Python");
            Title.text = AlertTitle + " " + AlertMessage;
            Message.text = "Adjusting player speed";
            PopUp.SetActive(true);

            controller = rpmcontroller.GetComponent<ThirdPersonMovement>();
            controller.walkSpeed = 6f;
            controller.runSpeed = 16f;
            config = -1;
        }
        else if(config == 1)
        {
            print("Config: "+ config+" Recieved from Python");
            Title.text = AlertTitle + " " + AlertMessage;
            Message.text = "Adjusting audio";
            PopUp.SetActive(true);

            VideoController.SetDirectAudioVolume(0, 0.25f);

            config = -1;

        }
        else if(config == 2)
        {
            print("Config: "+ config+" Recieved from Python");
            Title.text = AlertTitle + " " + AlertMessage;
            Message.text = "Adjusting Brightness";
            PopUp.SetActive(true);

            DirectionalLight1.SetActive(true);
            config = -1;

        }
    }
}
