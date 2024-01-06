using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class TheaterPopUpConfig : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer VideoController;

    private void OnEnable() {
        VideoController.SetDirectAudioVolume(0, 0.25f);
    }
}
