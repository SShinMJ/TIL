using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followObject;

    void LateUpdate()
    {
        transform.position = followObject.transform.position +
                                new Vector3(0, 0, -5);
    }
}
