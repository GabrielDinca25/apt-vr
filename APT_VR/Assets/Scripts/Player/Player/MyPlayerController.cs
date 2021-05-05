// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MyPlayerController : MonoBehaviour
// {
//     protected static MyPlayerController s_Instance;
//     public static MyPlayerController instance { get { return s_Instance; } }

//     protected PlayerInput m_Input;
//     //protected CharacterController m_CharCtrl;

//     public AbilityBase[] m_Abilities;

//     void Awake()
//     {
//         m_Input = GetComponent<PlayerInput>();
//         //m_CharCtrl = GetComponent<CharacterController>();

//         m_Abilities = GetComponents<AbilityBase>();

//         s_Instance = this;
//     }

//     void Update()
//     {
//         if (m_Input.ShotAbility)
//             m_Abilities[1].TriggerAbility();
//     }
// }
