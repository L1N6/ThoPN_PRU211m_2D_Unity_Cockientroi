using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform bearTransform;
    public float smoothSpeed = 0.125f;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y - bearTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 desiredPosition = new Vector3(transform.position.x, bearTransform.position.y + offset, transform.position.z); ;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
    }


}
