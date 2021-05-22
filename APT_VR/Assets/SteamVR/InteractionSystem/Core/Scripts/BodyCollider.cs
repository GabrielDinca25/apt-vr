//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Collider dangling from the player's head
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(BoxCollider))]
    public class BodyCollider : MonoBehaviour
    {
        public Transform head;

        private BoxCollider boxCollider;

        //-------------------------------------------------
        void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
        }


        //-------------------------------------------------
        void FixedUpdate()
        {
            float distanceFromFloor = Vector3.Dot(head.localPosition, Vector3.up);
            float y = Mathf.Max(boxCollider.size.y, distanceFromFloor);
            boxCollider.size = new Vector3(boxCollider.size.x, y, boxCollider.size.z);
            transform.localPosition = head.localPosition - 0.5f * distanceFromFloor * Vector3.up;
        }
    }
}
