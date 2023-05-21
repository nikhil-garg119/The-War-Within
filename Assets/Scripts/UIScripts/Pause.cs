using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public Dropdown difficultySetting;
    public GameObject[] extraSpawner;
    public AudioSource audio;
    public Button Resume;
    public Slider slider;
    private int extraSpawners=0;
    void Start()
    {
        Resume.onClick.AddListener(resume);
        difficultySetting.onValueChanged.AddListener(delegate {
            DropdownValueChanged(difficultySetting);});
    }
    void DropdownValueChanged(Dropdown change)
    {
        switch(change.value)
        {
            case 0: extraSpawner[0].SetActive(false); extraSpawner[1].SetActive(false); break;
            case 1: extraSpawner[0].SetActive(false); extraSpawner[1].SetActive(true); break;
            case 2: extraSpawner[0].SetActive(true); extraSpawner[1].SetActive(true); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        pauseMenu.SetActive(true);
        Time.timeScale=0;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        

    }
    audio.volume=slider.value;}
    void resume()
    {
        pauseMenu.SetActive(false);
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        Time.timeScale=1;

    }
}
