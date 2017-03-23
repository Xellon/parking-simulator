using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.FirstPerson{

    [RequireComponent(typeof (CharacterController))]
    public class FirstPersonController : MonoBehaviour{
        [SerializeField] private MouseLook m_MouseLook;

        private Camera m_Camera;

        // Use this for initialization
        private void Start(){
            m_Camera = Camera.main;
			m_MouseLook.Init(transform , m_Camera.transform);
        }

        // Update is called once per frame
        private void Update(){
            RotateView();
        }

        private void RotateView(){
            m_MouseLook.LookRotation (transform, m_Camera.transform);
        }
    }
}
