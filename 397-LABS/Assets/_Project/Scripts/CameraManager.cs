using Unity.Cinemachine;
using UnityEngine;

namespace Platformer397
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera freeLookCam;
        [SerializeField] private Transform player;

        private void Awake()
        {
            #if UNITY_EDITOR && !PLATFORM_ANDROID
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            #endif
            if (player != null) { return; }
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void OnEnable()
        {
            freeLookCam.Target.TrackingTarget = player;
        }
    }
}