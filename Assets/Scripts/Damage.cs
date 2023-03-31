using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public Slider slider;

    void Start()
    {
        slider.maxValue=health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=health;
        if(health<=0)
        {
            if(this.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(0);
        Destroy(this.transform.gameObject);
        //Animation Code To-Be-Added-Later

    }}
}
