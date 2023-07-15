using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinotaurs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minotaurPrefab;
    GameObject minotaurInstance;
    bool IsDead=false;
    public int WaveThreshold;
    managerKill mk;
    int c=0;
    void Start()
    {
        minotaurInstance=Instantiate(minotaurPrefab,this.transform.position,this.transform.rotation);
        mk=FindObjectOfType<managerKill>();
         mk.enemies.Add(minotaurInstance);
    }

    // Update is called once per frame
    void Update()
    {
        if(minotaurInstance.GetComponent<Damage>().health<=0 && !IsDead ){
        StartCoroutine("MoreMin");
        IsDead=true;
    }
    
    }
    IEnumerator MoreMin()
    {
        yield return new WaitForSeconds(2f);
        minotaurInstance=Instantiate(minotaurPrefab,this.transform.position,this.transform.rotation);
        mk.enemies.Add(minotaurInstance);
        this.transform.position=new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y,transform.position.z+Random.Range(-10,10));
        IsDead=false;
        c++;
    }
}
