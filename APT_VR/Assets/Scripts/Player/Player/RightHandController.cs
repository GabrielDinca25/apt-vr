// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Valve.VR;

// public class RightHandController : MonoBehaviour
// {
//     public SteamVR_Action_Vector2 ThumbstickAction = null;
//     public SteamVR_Action_Vector2 TrackpadAction = null;

//     public SteamVR_Action_Single SqueezeAction = null;
//     public SteamVR_Action_Boolean GripAction = null;
//     public SteamVR_Action_Boolean PinchAction = null;

//     public SteamVR_Action_Skeleton SkeletonAction = null;

//     public bool _thumb;
//     public bool _index;
//     public bool _middle;
//     public bool _ring;
//     public bool _pinky;

//     public bool coldown;
//     public bool canUse;
//     public float cooldownTime = 1;


//     public GameObject fireShot;
//     public GameObject firePrefab;
//     public Vector3 fireSpawnPosition;
//     public float force;
//     public int handIndex;
//     public int handIndexLength;
//     public Vector3[] handLastPositions;
//     public float[] handLastRotations;
//     public float fireShotRotationAngle;

//     // Start is called before the first frame update
//     void Start()
//     {
//         canUse = true;
//         handIndex = 0;
//         handLastPositions = new Vector3[60];
//         handLastRotations = new float[handIndexLength];
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         //Thumbstick();
//         //Squeeze();

//         //Grip();
//         //Pinch();
//         //Skeleton();

//         //UpdatePosition();
//         TrackFinger();
//         TriggerSpell();
//     }

//     private void TrackFinger()
//     {
//         _thumb = SkeletonAction.thumbCurl > 0.5f ? true : false;
//         _index = SkeletonAction.indexCurl > 0.5f ? true : false;
//         _middle = SkeletonAction.middleCurl > 0.5f ? true : false;
//         _ring = SkeletonAction.ringCurl > 0.5f ? true : false;
//         _pinky = SkeletonAction.pinkyCurl > 0.5f ? true : false;
//     }

//     private void TriggerSpell()
//     {
//         //bool fireBall2 = _thumb == true && _index == true && _middle == false && _ring == false && _pinky == false;
//         bool fireBall = _thumb == false && _index == false && _middle == true && _ring == true && _pinky == true;

//         if(fireBall) {
//             fireShot.SetActive(true);
//             if (canUse)
//             {
//                 bool fire = TriggerFireBall();

//                 if (fire)
//                 {
//                     FireBall();
//                     StartCooldown();
//                 }
//             }
//         } else {
//             fireShot.SetActive(false);
//         }
//     }

//     public void UpdatePosition()
//     {
//         handLastPositions[handIndex] = transform.position;
//         handLastRotations[handIndex] = transform.rotation.x;

//         handIndex++;
//         if (handIndex == handIndexLength)
//         {
//             handIndex = 0;
//         }
//     }

//     private bool TriggerFireBall()
//     {
//         //float handFirstRotation = handLastRotations[0].x;

//         //Debug.Log(handLastRotations[0]);
//         //Debug.Log(handLastRotations[handIndexLength - 1]);

//         if (Mathf.Abs(handLastRotations[0] - handLastRotations[handIndexLength-1]) > fireShotRotationAngle)
//         {
//             //Debug.Log(handLastRotations[0]);
//             //Debug.Log(handLastRotations[handIndexLength-1]);
//             fireSpawnPosition = handLastPositions[0];
//             return true;
//         }

//         return false;
//     }

//     void FireBall()
//     {
//         //Time.timeScale = 0.5f;
//         GameObject fireBall = Instantiate(firePrefab, fireSpawnPosition, transform.localRotation) as GameObject;
//         fireShot.SetActive(false);

//         fireBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
//     }
//     void StartCooldown()
//     {
//         StartCoroutine(Cooldown());
//         IEnumerator Cooldown()
//         {
//             canUse = false;
//             yield return new WaitForSeconds(cooldownTime);
//             fireShot.SetActive(true);
//             canUse = true;

//             //Time.timeScale = 1f;
//         }
//     }

//     private void Thumbstick()
//     {
//         if (ThumbstickAction.axis == Vector2.zero)
//             return;

//         Debug.Log("Thumbstick care e  Touchpad: " + ThumbstickAction.axis);
//     }

//     private void Squeeze()
//     {
//         if (SqueezeAction.axis == 0.0f)
//             return;

//         Debug.Log("SqueezeAction: " + SqueezeAction.axis);
//     }

//     private void Grip()
//     {
//         if (GripAction.stateDown)
//             Debug.Log("GripActionState : Down");

//         if (GripAction.stateUp)
//             Debug.Log("GripActionState : Down");
//     }

//     private void Pinch()
//     {
//         if (PinchAction.stateDown)
//             Debug.Log("PinchAction : Down");

//         if (PinchAction.stateUp)
//             Debug.Log("PinchAction : Down");
//     }

//     private void Skeleton()
//     {
//         //float[] allCurls = SkeletonAction.fingerCurls;

//         if(SkeletonAction.indexCurl > 0.2f)
//         {
//             print("Index: " + SkeletonAction.indexCurl);
//         }

//         if (SkeletonAction.middleCurl > 0.2f)
//         {
//             print("middleCurl: " + SkeletonAction.middleCurl);
//         }

//         if (SkeletonAction.ringCurl > 0.2f)
//         {
//             print("ringCurl: " + SkeletonAction.ringCurl);
//         }

//         if (SkeletonAction.pinkyCurl > 0.2f)
//         {
//             print("pinkyCurl: " + SkeletonAction.pinkyCurl);
//         }

//         if (SkeletonAction.thumbCurl > 0.2f)
//         {
//             print("thumbCurl: " + SkeletonAction.thumbCurl);
//         }
//     }
// }
