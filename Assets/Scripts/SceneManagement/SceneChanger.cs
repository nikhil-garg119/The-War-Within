using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        
    }
    public void OnClick(int x)
{

SceneManager.LoadScene(x);
}
void OnCollisionEnter(Collision other)
{
    if(other.gameObject.CompareTag("Player"))
    SceneManager.LoadScene(2);
}
public void Quit()
{
    Application.Quit();
}
}