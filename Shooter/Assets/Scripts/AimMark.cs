using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimMark : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private RectTransform canvasRectTransform;
    [SerializeField]
    private Animator animator;
    private Transform Target { get; set; }

    public void SetAimTarget(Transform target)
    {
        Target = target;
        PlayAimAnimation();
    }

    public void PlayAimAnimation()
    {
        animator.SetTrigger("Aim");
    }

    private void LateUpdate()
    {
        if(Target == null)
        {
            return;
        }

        var screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, Target.localPosition);
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, null, out var vector2))
        {
            transform.localPosition = vector2;
        }
    }
}
