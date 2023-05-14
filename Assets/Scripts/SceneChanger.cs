using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Cursor.visible=true;
    }
    public void OnClick(int x)
{

SceneManager.LoadScene(x);
}
}
