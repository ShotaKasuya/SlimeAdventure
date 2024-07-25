using System;
using Cinemachine;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class CameraEventOption
    {
        public bool ProvideCameraEvent => provideCameraEvent;
        public CinemachineVirtualCamera VirtualCamera => virtualCamera;
        public float EventTime => eventTime;

        [SerializeField] private bool provideCameraEvent;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float eventTime;
    }
}