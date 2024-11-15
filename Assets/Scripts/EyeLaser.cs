using UnityEngine;

public class EyeLaser : MonoBehaviour
{
    [Header("FOV Settings ")]

    [SerializeField] private Transform _targetOrigin;
    [SerializeField] private float _targetDistance = 1000f;
    [SerializeField] private LayerMask hitLayer;

    void Update()
    {
        FOV();
    }

    private void FOV()
    {
        Vector3 origin = _targetOrigin.position;
        RaycastHit hit;
        Debug.DrawLine(origin, _targetOrigin.transform.forward * _targetDistance, Color.red);

        if (Physics.Raycast(origin, _targetOrigin.forward, out hit, hitLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<Target>(out Target target ))
            {
                target.Targeted();
            }
        }
    }
}
