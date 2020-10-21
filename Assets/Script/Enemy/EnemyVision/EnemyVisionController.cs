using UnityEngine;

public class EnemyVisionController : MonoBehaviour
{
    public bool IsTargetInRayCast(GameObject target)
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, target.transform.position - this.transform.position);
        Physics.Raycast(ray, out hit);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.collider.gameObject == target.gameObject)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsTargetSeen(GameObject target)
    {
        var isTargetSeen = IsTargetInRayCast(target);

        return isTargetSeen && target.GetComponent<PlayerController>().state != PlayerController.State.hide;
    }
}
