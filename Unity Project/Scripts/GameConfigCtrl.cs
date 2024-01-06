using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.QuickStart;
using UnityEngine.UI;

public class GameConfigCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PopUp;
    [HideInInspector]public int config = -1; 
    [HideInInspector]public string AlertTitle = "";
    [HideInInspector]public string AlertMessage = "";
    public GameObject rpmcontroller; 
    public Light DirectionalLight1;
    public AudioSource song;
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

            song.volume = 0.5f;

            config = -1;

        }
        else if(config == 2)
        {
            print("Config: "+ config+" Recieved from Python");
            Title.text = AlertTitle + " " + AlertMessage;
            Message.text = "Adjusting Brightness";
            PopUp.SetActive(true);

            DirectionalLight1.intensity = 2;
            config = -1;

        }
    }
}
