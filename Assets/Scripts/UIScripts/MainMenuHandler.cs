using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pause.isPaused=false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        Time.timeScale=1;
    }
}
