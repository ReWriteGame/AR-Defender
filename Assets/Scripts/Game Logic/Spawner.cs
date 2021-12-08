using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private bool playOnAwake = true;
    [SerializeField] private bool infinity = true;
    [SerializeField] Vector2Int numberOfSpawns = Vector2Int.one;
    [SerializeField] Vector2 delayВetweenSpawns = Vector2.one;

    public UnityEvent startSpawnEvent;
    public UnityEvent stopSpawnEvent;
    public UnityEvent spawnPrefabEvent;

    private Coroutine currentCoroutine;

    private void Start()
    {
        if (playOnAwake) StartSpawn();
    }

    private IEnumerator StartSpawnCor()
    {
        while (infinity)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
        }

        for (int i = 0; i < Random.Range(numberOfSpawns.x, numberOfSpawns.y); i++)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
        }

        stopSpawnEvent?.Invoke();
        yield break;
    }


    public void StartSpawn()
    {
        startSpawnEvent?.Invoke();
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(StartSpawnCor());
    }


    public void StopSpawn()
    {
        stopSpawnEvent?.Invoke();
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
    }

    public void SpawnRandomPrefab()
    {
        spawnPrefabEvent?.Invoke();
        Instantiate(spawnerData.Prefabs[Random.Range(0, spawnerData.Prefabs.Count)], spawnParent).transform.localPosition = spawnPosition.position;
    }

    public void SpawnPrefab(GameObject prefab)
    {
        spawnPrefabEvent?.Invoke();
        var obj = Object.Instantiate(prefab);
        obj.transform.position = transform.position;
        // foreach (GameObject obj in spawnerData.Prefabs)
        // {
        //     if (PrefabUtility.GetPrefabInstanceHandle(prefab) == obj)
        //     {
        //         Instantiate(obj, spawnParent).transform.localPosition = spawnPosition.position;
        //         break;
        //     }
        // }

    }

    // в рандомном радиусе 
    // рандомное кол-во за раз
    // ивенты заспавнил начал спавнить закончил спавнить
    // время жизни 
    // бессконечная генерация
    // шанс выпадения каждого итема отдельно
}
