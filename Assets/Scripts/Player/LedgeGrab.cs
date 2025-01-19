using System.Threading.Tasks;
using StarterAssets;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private float wallRayMaxDir;
    [SerializeField] private float wallGroundRayMaxDir;
    [SerializeField] float movePoint;
    [SerializeField] private ThirdPersonController scr_thirdPersonController;
    private bool grabbedWall = false;
    private Vector3 wallGroundPosition;

    private void Start()
    {
        scr_thirdPersonController.OnMoveWhileGrabbing += ClimeWhileGrabbing;
    }

    private void Update()
    {
        if (grabbedWall)
        {
            scr_thirdPersonController.IsGrabbing = true;
            scr_thirdPersonController.activeGravity = false;
        }
    }

    private void ClimeWhileGrabbing()
    {
        transform.position = wallGroundPosition;
        Wait();
    }

    private async void Wait()
    {
        await Task.Delay(100);
        scr_thirdPersonController.IsGrabbing = false;
        scr_thirdPersonController.activeGravity = true;
        grabbedWall = false;
    }

    private void FixedUpdate()
    {
        RaycastHit ledgeRaycastHit;

        if (!grabbedWall && !scr_thirdPersonController.Grounded)
        {
            if (Physics.Raycast(transform.position + positionOffset, transform.forward, out ledgeRaycastHit, wallRayMaxDir, layerMask))
            {
                RaycastHit wallGroundRaycastHit;
                Vector3 movedPoint = new Vector3(ledgeRaycastHit.point.x, ledgeRaycastHit.point.y + movePoint, ledgeRaycastHit.point.z);
                Vector3 rayDirectionDown = transform.forward + transform.up * -1;

                if (Physics.Raycast(movedPoint, rayDirectionDown, out wallGroundRaycastHit, wallGroundRayMaxDir, layerMask))
                {
                    grabbedWall = true;
                    wallGroundPosition = wallGroundRaycastHit.point;
                    Vector3 holdingLedgePosition = new Vector3(transform.position.x, wallGroundPosition.y - 1.25f, transform.position.z);
                    transform.position = holdingLedgePosition;
                }
            }
        }
    }


}
