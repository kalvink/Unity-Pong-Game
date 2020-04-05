using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {


    public void MuteMusic(bool muteMusic){
        if (muteMusic == true)
        {
            AudioListener.volume = 0;
        }

        if (muteMusic == false) {
            AudioListener.volume = 1;

        }
    }

}
