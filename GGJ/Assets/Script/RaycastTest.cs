using UnityEngine;

public class DebugRayTest : MonoBehaviour
{
    public float raycastDistance = 100f;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, Color.magenta);
    }
}
