using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        private const string _HorizontalAxisName = "Horizontal";
        private const string _VerticalAxisName = "Vertical";

        private bool enabled = true;
        public bool Enabled { get => enabled; set => enabled = value; }

        public Vector2 MovementAxis => GetMovementAxis();

        private Vector2 GetMovementAxis()
        {
            if (!enabled) return Vector2.zero;

            if (VirtualJoystick.Value != Vector2.zero)
                return VirtualJoystick.Value;

            return new Vector2(UnityEngine.Input.GetAxis(_HorizontalAxisName), UnityEngine.Input.GetAxis(_VerticalAxisName));
        }
    }
}