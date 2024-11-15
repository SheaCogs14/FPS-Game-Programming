using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollect playerCollect = other.GetComponent<PlayerCollect>();

        playerCollect.UpdateScore();
        Destroy(gameObject);
    }
}
