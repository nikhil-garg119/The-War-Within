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
    [SerializeField]float DeathForceWraith=1f;
    [SerializeField]float DeathForcePlayer=10f;
    managerKill mk;
    private bool IsDead=false;

    void Start()
    {
        slider.maxValue=health;
        if(this.gameObject.CompareTag("Minotaurs"))
        {
        animator=GetComponent<Animator>();
        mk=FindObjectOfType<managerKill>();
    }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=health;
        if(health<=0)
        {
            if(this.gameObject.CompareTag("Player"))
            StartCoroutine("DeathPlayer");
           
            
            if(this.gameObject.CompareTag("Minotaurs") && !IsDead) 
            {
                animator.SetBool("IsDead",true);
                StartCoroutine("KillAnimMinotaur");
                IsDead=true;
            }
            if(this.gameObject.CompareTag("AngWraiths") && !IsDead) 
            {
            
                StartCoroutine("KillAnimAngWraiths");
                IsDead=true;
            }
        //Animation Code To-Be-Added-Later
        //if(this.gameObject.CompareTag("AngWraiths"))
        
    }}
    IEnumerator KillAnimMinotaur()
    {
        this.gameObject.GetComponent<MinotaurAI>().enabled=false;
         this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
         mk.enemies.Remove(this.gameObject);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    IEnumerator DeathPlayer()
    {
        this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
        Destroy(this.GetComponent<PlayerMovementScript>());
        Destroy(this.GetComponent<MouseLookScript>());
        Destroy(this.GetComponent<GunInventory>().currentGun);
        Destroy(this.GetComponent<GunInventory>());
        this.GetComponent<Rigidbody>().AddForce(-this.transform.forward*DeathForcePlayer,ForceMode.Impulse);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    IEnumerator KillAnimAngWraiths()
    {
        Destroy(this.GetComponent<UnityEngine.AI.NavMeshAgent>());
        Destroy(this.GetComponent<AngWraithAI>());
        this.gameObject.AddComponent<Rigidbody>().AddForce(-this.transform.forward*DeathForceWraith,ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
