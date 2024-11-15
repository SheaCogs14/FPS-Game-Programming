using UnityEngine;

public class Target : MonoBehaviour
{
    private Material _currentMaterial;

    [SerializeField] private Color _targetColour = Color.red;
    private Color _initialColor;

    private void Awake()
    {
        _currentMaterial = GetComponent<Renderer>().material;
        _initialColor = _currentMaterial.color;
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void Targeted()
    {
        _currentMaterial.color = _targetColour;
    }

    public void StopTarget()
    {
        _currentMaterial.color = _initialColor;
    }
}
