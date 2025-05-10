using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorZombies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int enemyAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop ()
    {
        while (enemyCount < enemyAmount)
        {
            xPos = Random.Range(256, 791);
            zPos = Random.Range(256, 790);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
