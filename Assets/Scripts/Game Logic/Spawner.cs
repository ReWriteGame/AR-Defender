using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnParent;
    [SerializeField] Vector2Int numberOfSpawns = Vector2Int.one;
    [SerializeField] Vector2 delayВetweenSpawns = Vector2.one;

    public UnityEvent startSpawnEvent;
    public UnityEvent stopSpawnEvent;
    public UnityEvent spawnPrefabEvent;

    private Coroutine currentCoroutine;

   
    public void SpawnPrefab(GameObject prefab)
    {
        spawnPrefabEvent?.Invoke();
        var obj = Object.Instantiate(prefab, spawnParent);
        obj.transform.localPosition = Vector3.zero;
    }

    // в рандомном радиусе 
    // рандомное кол-во за раз
    // ивенты заспавнил начал спавнить закончил спавнить
    // время жизни 
    // бессконечная генерация
    // шанс выпадения каждого итема отдельно
}
