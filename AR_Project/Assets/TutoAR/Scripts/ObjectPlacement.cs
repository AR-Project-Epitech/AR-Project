using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectPlacement : MonoBehaviour
{
    public GameObject placedObject;
    GameObject spawedObject;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> rayHits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0))
        {
            touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            return true;
        }
#else
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(raycastManager.Raycast(touchPosition, rayHits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = rayHits[0].pose;
            if(spawedObject == null)
            {
                spawedObject = Instantiate(placedObject, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawedObject.transform.position = hitPose.position;
            }
        }
    }
}
