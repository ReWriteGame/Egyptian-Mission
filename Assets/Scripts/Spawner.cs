using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;

    public Transform spawnPosition;
    public bool playOnAwake = true;

    [SerializeField] private Vector2Int numberOfSpawns;
    [SerializeField] private Vector2 delayВetweenSpawns;

    [SerializeField] private GameObject currentNeedle;

    private void Start()
    {
        if(playOnAwake)
            StartCoroutine(startSpawnCor());
    }

    private IEnumerator startSpawnCor()
    {
        for (int i = 0; i < Random.Range(numberOfSpawns.x, numberOfSpawns.y); i++)
        {
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
            spawnObject();
        }

        yield break;
    }
    public void spawnObject()
    {
        currentNeedle = Instantiate(spawnerData.Prefabs[Random.Range(0, spawnerData.Prefabs.Count)], spawnPosition);
        currentNeedle.transform.localPosition = Vector3.zero;
    }

    public void shot()
    {
        currentNeedle.GetComponent<Rigidbody2D>().AddForce(Vector2.up * currentNeedle.GetComponent<Needle>().Speed, ForceMode2D.Impulse);
    }


    // в рандомном радиусе 
    // рандомное кол-во за раз
    // ивенты заспавнил начал спавнить закончил спавнить
    // время жизни 
    // бессконечная генерация
    // шанс выпадения каждого итема отдельно
}
