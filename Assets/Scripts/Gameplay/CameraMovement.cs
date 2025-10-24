using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform followObject;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if (followObject == null)
            return;

        transform.position = followObject.position + offset;
        transform.LookAt(followObject.position);
    }

    public void SetTarget(Transform target)
    {
        followObject = target;
    }
}
