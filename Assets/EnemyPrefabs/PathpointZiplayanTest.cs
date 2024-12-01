using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathpointZiplayanTest : MonoBehaviour
{
    [SerializeField] private Transform pointA;   // Start point of Bézier curve
    [SerializeField] private Transform pointB;   // Control point of Bézier curve
    [SerializeField] private Transform pointC;   // End point of Bézier curve and start point of linear interpolation
    [SerializeField] private Transform pointD;   // End point of linear interpolation
    [SerializeField] private Transform parentObject; // Parent object to move along the path [Optional, if not assigne
    [SerializeField] private Transform PathpointParent;

    [SerializeField] private Transform pointMover; // Object that moves along the path
    [SerializeField] private float waitTime = 1f; // Time to wait at pointC
    [SerializeField] private float speed = 1f;   // Speed of interpolation

    [SerializeField] private Animator _animator;
    private void Start()
    {
        StartCoroutine(MoveAlongPath());
    }

    private IEnumerator MoveAlongPath()
    {
        while (true) // Loop indefinitely
        {
            ChangeAnimationStateFrogJump();
            // Step 1: Interpolate along the Bézier curve (A to C)
            yield return StartCoroutine(MoveBezier(pointA.position, pointB.position, pointC.position));

            // Step 2: Wait for the specified time
            yield return new WaitForSeconds(waitTime);

            ChangeAnimationStateFrogIdle();
            // Step 3: Interpolate from C to D
            yield return StartCoroutine(MoveLinear(pointC.position, pointD.position));

            // Step 4: Wait again at point D before looping
            yield return new WaitForSeconds(waitTime);

            // Step 5: Change Pathpoints along to change location.
            yield return StartCoroutine(MoveLinearPathpoints(pointA.position, pointD.position));

            // Step 6: wait for specified time
            yield return new WaitForSeconds(waitTime);

        }
    }

    private IEnumerator MoveBezier(Vector3 start, Vector3 control, Vector3 end)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            // Bézier interpolation formula: B(t) = (1-t)^2 * A + 2 * (1-t) * t * B + t^2 * C
            Vector3 position = Mathf.Pow(1 - t, 2) * start +
                               2 * (1 - t) * t * control +
                               Mathf.Pow(t, 2) * end;
            pointMover.position = position;
            yield return null;
        }
        pointMover.position = end; // Ensure it snaps to the end
    }

    private IEnumerator MoveLinear(Vector3 start, Vector3 end)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            pointMover.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        pointMover.position = end; // Ensure it snaps to the end
    }
    private IEnumerator MoveLinearPathpoints(Vector3 start, Vector3 end)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            PathpointParent.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        PathpointParent.position = end; // Ensure it snaps to the end
    }
    // 
    private void ChangeAnimationStateFrogJump()
    {
        _animator.SetBool("IsJumpingFrog", true);
    }
    private void ChangeAnimationStateFrogIdle()
    {
    {
        _animator.SetBool("IsJumpingFrog", false);   }
    }
}
