// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerInput : MonoBehaviour
// {
//     protected static PlayerInput s_Instance;

//     public static PlayerInput Instance { get { return s_Instance; } }

//     public bool playerControllerInputBlocked;
//     protected bool m_Attack;
//     protected bool m_Pause;
//     protected bool m_Aim;
//     protected bool m_ShotAbility;
//     protected bool m_Ability2;
//     protected bool m_ExternalInputBlocked;

//     public bool Pause
//     {
//         get { return m_Pause; }
//     }

//     public bool Aim
//     {
//         get { return m_Aim && !playerControllerInputBlocked && !m_ExternalInputBlocked; }
//     }

//     public bool ShotAbility
//     {
//         get { return m_ShotAbility && !playerControllerInputBlocked && !m_ExternalInputBlocked; }
//     }
//     public bool Ability2
//     {
//         get { return m_Ability2 && !playerControllerInputBlocked && !m_ExternalInputBlocked; }
//     }

//     WaitForSeconds m_AttackInputWait;
//     Coroutine m_AttackWaitCoroutine;

//     const float k_AttackInputDuration = 0.03f;

//     void Awake()
//     {
//         m_AttackInputWait = new WaitForSeconds(k_AttackInputDuration);

//         if (s_Instance == null)
//             s_Instance = this;
//         else if (s_Instance != this)
//             throw new UnityException("There cannot be more than one PlayerInput script.  The instances are " + s_Instance.name + " and " + name + ".");
//     }

//     void OnFire()
//     {
//         if (m_AttackWaitCoroutine != null)
//             StopCoroutine(m_AttackWaitCoroutine);

//         m_AttackWaitCoroutine = StartCoroutine(AttackWait());
//     }

//     void OnShotAbility(bool status)
//     {
//         m_ShotAbility = status;
//     }

//     void OnAbility2(bool status)
//     {

//         m_Ability2 = status;
//     }


//     IEnumerator AttackWait()
//     {
//         m_Attack = true;

//         yield return m_AttackInputWait;

//         m_Attack = false;
//     }

//     public bool HaveControl()
//     {
//         return !m_ExternalInputBlocked;
//     }

//     //public void ReleaseControl()
//     //{
//     //    m_ExternalInputBlocked = true;
//     //}

//     //public void GainControl()
//     //{
//     //    m_ExternalInputBlocked = false;
//     //}
// }
