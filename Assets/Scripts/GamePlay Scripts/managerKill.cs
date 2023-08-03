using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerKill : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies;
    public GameObject enemyPointer;
    public GameObject player;
    
    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        enemyPointer.SetActive(true);
        if(Input.GetKeyUp(KeyCode.E))
       enemyPointer.SetActive(false);
        Quaternion rotation=Quaternion.LookRotation(nearestEnemy().transform.position-player.transform.position);
        enemyPointer.transform.rotation=Quaternion.Euler(0,0,player.transform.rotation.eulerAngles.y-rotation.eulerAngles.y);

    }
    GameObject nearestEnemy()
    {
        GameObject nearestenemy=enemies[0];
        for(int i=1;i<enemies.Count;i++)
        {
            if(Vector3.Distance(player.transform.position,nearestenemy.transform.position)>=Vector3.Distance(player.transform.position,enemies[i].transform.position))
            nearestenemy=enemies[i];
        }
        return nearestenemy;
    }
}
