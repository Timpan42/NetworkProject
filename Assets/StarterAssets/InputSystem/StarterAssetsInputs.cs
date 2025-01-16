using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool EmotOne;
		public bool EmotTwo;
		public bool EmotThree;
		public bool EmotFour;
		public Vector3 rotation;
		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
		public void OnEmotOne(InputValue value)
		{
			EmotOneInput(value.isPressed);
		}
		public void OnEmotTwo(InputValue value)
		{
			EmotTwoInput(value.isPressed);
		}
		public void OnEmotThree(InputValue value)
		{
			EmotThreeInput(value.isPressed);
		}
		public void OnEmotFour(InputValue value)
		{
			EmotFourInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		public void EmotOneInput(bool newEmotState)
		{
			EmotOne = newEmotState;
		}
		public void EmotTwoInput(bool newEmotState)
		{
			EmotTwo = newEmotState;
		}
		public void EmotThreeInput(bool newEmotState)
		{
			EmotThree = newEmotState;
		}
		public void EmotFourInput(bool newEmotState)
		{
			EmotFour = newEmotState;
		}
		public void CameraRotationInput(Vector3 newRotation)
		{
			rotation = newRotation;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

}