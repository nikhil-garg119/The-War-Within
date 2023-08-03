using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensiChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public MouseLookScript mls;
    void Start()
    {
        slider.value=1;
    }

    // Update is called once per frame
}
