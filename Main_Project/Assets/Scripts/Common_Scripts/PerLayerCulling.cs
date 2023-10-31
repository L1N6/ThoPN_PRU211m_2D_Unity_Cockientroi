using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerLayerCulling : MonoBehaviour
{
    public Camera mainCamera;
    public Camera miniCamera;

    void LateUpdate()
    {
        Ray ray = miniCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit[] hits = Physics.RaycastAll(ray);

        float[] distances = new float[32]; 

        foreach (RaycastHit hit in hits)
        {
            int layer = hit.collider.gameObject.layer;
            float distance = Vector3.Distance(miniCamera.transform.position, hit.point);

            
            distances[layer] = Mathf.Max(distances[layer], distance);
        }

        miniCamera.layerCullSpherical = true;
        miniCamera.layerCullDistances = distances;
    }
}

