using UnityEngine;

public class LightingCycle : MonoBehaviour
{
    Vector3 rotate = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        rotate.x = 2 * Time.deltaTime;
        transform.Rotate(rotate, Space.World);
    }
}
