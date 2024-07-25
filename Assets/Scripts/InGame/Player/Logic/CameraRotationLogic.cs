using System;
using InGame.Player.View;
using InGame.ScriptableObjects;
using StaticVariables;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class CameraRotationLogic : ITickable, IDisposable
    {
        [Inject]
        public CameraRotationLogic(ChildComponentView childComponentView,
            PlayerInput playerInput, CameraConstant cameraConstant)
        {
            CameraConstant = cameraConstant;
            ChildComponentView = childComponentView;
            CameraAction = playerInput.actions[InputDefinition.CameraAction];

            _cameraRotation = ChildComponentView.CameraTransform.eulerAngles;
        }

        // https://www.popii33.com/unity-first-person-camera/
        public void Tick()
        {
            var rot = ReadValue() * OptionalSettingValues.Sensitivity * CameraConstant.SenseBase * Time.deltaTime;

            _cameraRotation += new Vector3(-rot.y, rot.x, 0);

            _cameraRotation = ClampRotation(_cameraRotation);

            ChildComponentView.CameraRotator.eulerAngles = _cameraRotation;
        }

        private Vector3 ClampRotation(Vector3 vector3)
        {
            vector3.x = Mathf.Clamp(vector3.x, CameraConstant.CameraRotationXMin, CameraConstant.CameraRotationXMax);

            return vector3;
        }

        private Vector2 ReadValue()
        {
            return CameraAction.ReadValue<Vector2>();
        }

        private CameraConstant CameraConstant { get; }
        private ChildComponentView ChildComponentView { get; }
        private InputAction CameraAction { get; }
        private Vector3 _cameraRotation;

        public void Dispose()
        {
            CameraAction.Dispose();
        }
    }
}