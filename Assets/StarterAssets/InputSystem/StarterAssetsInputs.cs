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
		public bool EmoteOne;
		public bool EmoteTwo;
		public bool EmoteThree;
		public bool EmoteFour;
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
		public void OnEmoteOne(InputValue value)
		{
			EmoteOneInput(value.isPressed);
		}
		public void OnEmoteTwo(InputValue value)
		{
			EmoteTwoInput(value.isPressed);
		}
		public void OnEmoteThree(InputValue value)
		{
			EmoteThreeInput(value.isPressed);
		}
		public void OnEmoteFour(InputValue value)
		{
			EmoteFourInput(value.isPressed);
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
		public void EmoteOneInput(bool newEmoteState)
		{
			EmoteOne = newEmoteState;
		}
		public void EmoteTwoInput(bool newEmoteState)
		{
			EmoteTwo = newEmoteState;

		}
		public void EmoteThreeInput(bool newEmoteState)
		{
			EmoteThree = newEmoteState;
		}
		public void EmoteFourInput(bool newEmoteState)
		{
			EmoteFour = newEmoteState;
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