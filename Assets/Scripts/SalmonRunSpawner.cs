using System.Collections;
using UnityEngine;

public class SalmonRunSpawner : MonoBehaviour
{
    private Collider2D SpawnArea;

    public GameObject Salmon;

    public float MinSpawnDelay = 5f;
    public float MaxSpawnDelay = 15f;

    public float MinVelocity = 10f;
    public float MaxVelocity = 15f;

    public float Lifetime = 3f;

    private void Awake()
    {
        SpawnArea = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject Prefab = Salmon;

            Vector2 Coordinate = new Vector2();
            Coordinate.x = Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
            Coordinate.y = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);

            GameObject Fish = Instantiate(Prefab, Coordinate, Quaternion.identity);
            Destroy(Fish, Lifetime);

            float Speed = Random.Range(MinVelocity, MaxVelocity);
            Fish.GetComponent<Rigidbody2D>().AddForce(Fish.transform.right * Speed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));
        }
    }
}
