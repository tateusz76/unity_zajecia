using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject slime;

    [SerializeField]
    private float spawnRate = 3.5f;
    private float x,y;
    private Vector2 pos;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRate,slime));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        
        yield return new WaitForSeconds(interval);
        GameObject newSlime = objectPool.SharedInstance.GetPooledObject();

        if(newSlime !=null)
        {
            x = Random.Range(-11, 11);
            y = Random.Range(-6, 9);
            pos = new Vector2(x, y);
            
            newSlime.transform.position = pos;
            newSlime.SetActive(true);
        }

        StartCoroutine(spawnEnemy(interval,enemy));
    }
}
