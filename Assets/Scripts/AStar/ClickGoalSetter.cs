using UnityEngine;

public class ClickGoalSetter : MonoBehaviour
{
    public Camera mainCamera;
    public Transform goalMarker;
    public AStarPathfinder pathfinder;

    public LayerMask groundMask;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray =
            mainCamera.ScreenPointToRay(
                Input.mousePosition
            );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            100f,
            groundMask))
        {
            GridNode node =
            pathfinder.gridManager.NodeFromWorldPosition(hit.point);
                if (node != null && node.walkable)
                    {
                        goalMarker.position =
                            node.worldPosition + Vector3.up * 0.2f;

                        pathfinder.FindPath();
                    }
        }
    }
}