using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameEnv;
    public GameObject TheaterEnv;

    public string location;
    
    private void Start() {
        location = "0";
        if(TheaterEnv.activeSelf){
            location = "4";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            GameEnv.SetActive(true);
            TheaterEnv.SetActive(false);
            location = "0";
        }else if(Input.GetKey(KeyCode.Alpha2)){
            GameEnv.SetActive(false);
            TheaterEnv.SetActive(true);
            location = "4";
        }
    }
}
