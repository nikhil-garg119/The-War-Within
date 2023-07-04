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
    Animator animator;
    private bool IsDead=false;

    void Start()
    {
        slider.maxValue=health;
        if(this.gameObject.CompareTag("Minotaurs"))
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=health;
        if(health<=0)
        {
            if(this.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(0);

        Destroy(this.transform.gameObject);
            }
            if(this.gameObject.CompareTag("Minotaurs") && !IsDead) 
            {
                animator.SetBool("IsDead",true);
                StartCoroutine("KillAnim");
                IsDead=true;
            }
        //Animation Code To-Be-Added-Later
        //if(this.gameObject.CompareTag("AngWraiths"))
        Destroy(this.gameObject);
    }}
    IEnumerator KillAnim()
    {
        this.gameObject.GetComponent<MinotaurAI>().enabled=false;
         this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
