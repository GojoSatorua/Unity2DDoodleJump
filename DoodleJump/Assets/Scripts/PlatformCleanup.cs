using UnityEngine;

public class PlatformCleanup : MonoBehaviour
{
    [SerializeField] private float extraOffset = 2f;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (mainCam == null) return;

        float bottomEdge = mainCam.transform.position.y - mainCam.orthographicSize - extraOffset;

        if (transform.position.y < bottomEdge)
        {
            Destroy(gameObject);
        }
    }
}