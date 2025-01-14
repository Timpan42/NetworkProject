using UnityEngine;

public class CheckPointDetector : MonoBehaviour
{
    [SerializeField] private int checkPointId = 0;
    [SerializeField] private Transform checkPointTransform;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerManger>())
            {
                collider.GetComponent<PlayerManger>().UpdateCheckPoint(checkPointId, checkPointTransform);
            }
        }
    }
}
