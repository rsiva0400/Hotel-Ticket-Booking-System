using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpClosingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PopUp;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return)){
            PopUp.SetActive(false);
        }
    }
}
