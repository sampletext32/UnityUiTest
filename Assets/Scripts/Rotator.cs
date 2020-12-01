using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Rotator : MonoBehaviour
{
    private RectTransform selfTransform;
    private float anglesPerSecond = 60;

    // Start is called before the first frame update
    private void Start()
    {
        selfTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        selfTransform.Rotate(Vector3.back, anglesPerSecond * Time.deltaTime);
    }

    public void Reset()
    {
        selfTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}