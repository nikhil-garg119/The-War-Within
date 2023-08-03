using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCompass : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mazeEnd;
     [SerializeField] GameObject player;
    [SerializeField] GameObject mazeCompass;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Quaternion rotation=Quaternion.LookRotation(mazeEnd.transform.position-player.transform.position);
        mazeCompass.transform.rotation=Quaternion.Euler(0,0,player.transform.rotation.eulerAngles.y-rotation.eulerAngles.y);
        if(Input.GetKeyDown(KeyCode.E))
        mazeCompass.SetActive(true);
        if(Input.GetKeyUp(KeyCode.E))
        mazeCompass.SetActive(false);
    }
}
