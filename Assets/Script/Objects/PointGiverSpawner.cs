using System.Collections;
using UnityEngine;

public class PointGiverSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] GameObject pointGiverPrefab;
    [SerializeField] float fallSpeed = 5f;
    [SerializeField] float pointGiverLifetime = 5f;
    [SerializeField] float minimumSpawnTime = 7f;
    [SerializeField] float maximumSpawnTime = 15f;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float leftBoundPadding = 0.5f;
    [SerializeField] float rightBoundPadding = 0.5f;

    Coroutine spawnCoroutine;

    Vector2 minBounds;
    Vector2 maxBounds;
    int moveDirection = 1; // 1 = right, -1 = left

    private void Start()
    {
        InitBounds();
        spawnCoroutine = StartCoroutine(SpawnContinuously());
    }

    private void Update()
    {
        MoveSpawner();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MoveSpawner()
    {
        Vector3 newPos = transform.position;
        newPos.x += moveSpeed * moveDirection * Time.deltaTime;

        if (newPos.x <= minBounds.x + leftBoundPadding)
        {
            newPos.x = minBounds.x + leftBoundPadding;
            moveDirection = 1;
        }
        else if (newPos.x >= maxBounds.x - rightBoundPadding)
        {
            newPos.x = maxBounds.x - rightBoundPadding;
            moveDirection = -1;
        }

        transform.position = newPos;
    }

    IEnumerator SpawnContinuously()
    {
        NextLevel nextLevel = GetComponent<NextLevel>();

        while (true)
        {
            float waitTime = Random.Range(minimumSpawnTime, maximumSpawnTime);
            yield return new WaitForSeconds(waitTime);

            GameObject pointGiver = Instantiate(
                pointGiverPrefab,
                transform.position,
                Quaternion.identity
            );

            Rigidbody2D rb = pointGiver.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.down * fallSpeed;
            }

            // Start a coroutine to handle destruction + notifying next level
            StartCoroutine(DestroyPointGiverAfterTime(pointGiver, nextLevel));
        }
    }

    IEnumerator DestroyPointGiverAfterTime(GameObject pointGiver, NextLevel nextLevel)
    {
        yield return new WaitForSeconds(pointGiverLifetime);

        if (pointGiver != null)
            Destroy(pointGiver);

        nextLevel.StarDestroyed();
    }
}
