using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform car;
    [SerializeField] private float camSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        translation();
        rotate();
    }

    private void translation(){
        var carPos = car.TransformPoint(offset);

        transform.position = Vector3.Lerp(transform.position, carPos, camSpeed * Time.deltaTime);
    }

    private void rotate(){
        var dir = car.position - transform.position;
        var rotation = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
