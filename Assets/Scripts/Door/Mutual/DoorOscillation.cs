using UnityEngine;
using System.Collections;

public class DoorOscillation : MonoBehaviour
{
    public enum DoorSide { Left, Right }
    public DoorSide doorSide;

    private HingeJoint hinge;
    private bool isOscillating = false;
    private float oscillationDuration = 0.5f; // Her bir salınımın süresi
    private float targetPosition; // Hedef pozisyon, derece cinsinden

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();
        targetPosition = (doorSide == DoorSide.Left) ? 90f : -90f;
    }

    public void StartOscillation()
    {
        if (!isOscillating)
        {
            isOscillating = true;
            StartCoroutine(Oscillate());
        }
    }

    private IEnumerator Oscillate()
    {
        JointSpring spring = hinge.spring;
        spring.spring = 10f; // Yay kuvveti
        spring.damper = 1f; // Sönümleme kuvveti

        // Kapıyı aç
        spring.targetPosition = targetPosition;
        hinge.spring = spring;
        hinge.useSpring = true;
        yield return new WaitForSeconds(oscillationDuration);

        // Kapıyı kapat
        spring.targetPosition = -targetPosition; // Kapıyı başlangıç pozisyonuna getir
        hinge.spring = spring;
        hinge.useSpring = true;
        yield return new WaitForSeconds(oscillationDuration);

        hinge.useSpring = false;
        isOscillating = false;
    }
}