using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] transitionProps;
    public GameObject[] levelObjects;//Mainly Wraiths
    public GameObject ground;
    public GameObject player;
    public float TimeRotation;
    private Quaternion FinalRotation;
    public float Timer=0f;
    void Start()
    {
        
        //player=GameObject.FindWithTag("Player");
        Vector3 fR=new Vector3(-48.4f,0f,player.transform.rotation.z);
        FinalRotation=Quaternion.Euler(fR.x,fR.y,fR.z);
    }
    void Update()
    {
        if(Vector3.Distance(this.transform.position,player.transform.position)<1.5f){
            player.transform.rotation=Quaternion.Lerp(player.transform.rotation,FinalRotation,Timer);
        Timer+=Time.deltaTime*.5f;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        ChangeLevel();
    }
    void ChangeLevel()
    {
        for(int i=0;i<transitionProps.Length;i++)
        {
            transitionProps[i].SetActive(true);
        }
        for(int i=0;i<levelObjects.Length;i++)
        {
            levelObjects[i].SetActive(false);
        }
        player.GetComponent<PlayerMovementScript>().enabled=false;
        player.GetComponent<MouseLookScript>().enabled=false;
        StartCoroutine("DisGround");
        
        
    
    }
    IEnumerator DisGround()
    {
        yield return new WaitForSeconds(3f);
        ground.SetActive(false);
    }
}
