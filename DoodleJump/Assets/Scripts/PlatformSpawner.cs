using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject platformPrefab;

    [Header("Spawn Area:")]
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;
    [SerializeField] private float minYGap = 1.0f;
    [SerializeField] private float maxYGap = 1.5f;
    [SerializeField] private float spawnAheadDistance = 12f;

    private float highestY;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        float baseY = player != null ? player.position.y : transform.position.y;
        highestY = baseY - 2f;

        SpawnUntil(baseY + spawnAheadDistance);
    }

    private void Update()
    {
        if (platformPrefab == null) return;

        float topEdge = mainCam != null
            ? mainCam.transform.position.y + mainCam.orthographicSize
            : (player != null ? player.position.y : highestY);

        float desiredTop = topEdge + spawnAheadDistance;

        // Страховка: если игрок/камера как-то обогнали highestY
        if (highestY < topEdge)
        {
            highestY = topEdge;
        }

        SpawnUntil(desiredTop);
    }

    private void SpawnUntil(float targetY)
    {
        float safeMinGap = Mathf.Max(0.2f, minYGap);
        float safeMaxGap = Mathf.Max(safeMinGap, maxYGap);

        int safetyCounter = 0;
        while (highestY < targetY && safetyCounter < 200)
        {
            highestY += Random.Range(safeMinGap, safeMaxGap);
            float randomX = Random.Range(minX, maxX);
            Instantiate(platformPrefab, new Vector3(randomX, highestY, 0f), Quaternion.identity);
            safetyCounter++;
        }
    }
}