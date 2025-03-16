using System;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private Transform leftPupil;
    [SerializeField] private Transform rightPupil;
    private Transform leftEye;
    private Transform rightEye;
    private float maxPupilMovement;
    private Transform ball;

    void Start()
    {
        leftEye = leftPupil.parent;
        rightEye = rightPupil.parent;
        maxPupilMovement = (rightEye.lossyScale.x - rightPupil.lossyScale.x) * 2f;
        ball = FindFirstObjectByType<Ball>().transform;
    }

    void Update()
    {
        Vector3 directionToBall = ball.position - leftEye.position;
        directionToBall = Vector3.ProjectOnPlane(Quaternion.Euler(-90, 0, 0) * directionToBall, Vector3.forward).normalized;
        leftPupil.localPosition = directionToBall * maxPupilMovement + new Vector3(0, 0, -0.05f);
        directionToBall = ball.position - rightEye.position;
        directionToBall = Vector3.ProjectOnPlane(Quaternion.Euler(-90, 0, 0) * directionToBall, Vector3.forward).normalized;
        Debug.Log("Direction to ball: " + directionToBall);
        rightPupil.localPosition = directionToBall * maxPupilMovement + new Vector3(0, 0, -0.05f);
    }
}
