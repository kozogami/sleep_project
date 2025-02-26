using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearShifter : MonoBehaviour
{
    [Header("Gear Positions (Assign in Inspector)")]
    public Transform gear1;          // U
    public Transform gear2;          // M
    public Transform gear3;          // I
    public Transform gear4;          // Comma
    public Transform gear5;          // O
    public Transform reverse;        // Period
    public Transform neutral1_2;     // J
    public Transform neutral3_4;     // K
    public Transform neutral5_R;     // L

    private Transform targetGear;
    private bool isClutchEngaged = false;
    private bool isShifting = false;
    private KeyCode currentGearKey;
    private Vector3 originalPosition;

    [Header("Settings")]
    public float shiftSpeed = 3f;
    public float shiftThreshold = 0.1f;

    void Update()
    {
        HandleClutch();

        if (isClutchEngaged && !isShifting)
        {
            CheckGearInput();
        }
    }

    void HandleClutch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isClutchEngaged = true;
            originalPosition = transform.position;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            isClutchEngaged = false;
        }
    }

    void CheckGearInput()
    {
        if (Input.GetKeyDown(KeyCode.U)) StartGearShift(KeyCode.U, gear1);
        if (Input.GetKeyDown(KeyCode.I)) StartGearShift(KeyCode.I, gear3);
        if (Input.GetKeyDown(KeyCode.O)) StartGearShift(KeyCode.O, gear5);
        if (Input.GetKeyDown(KeyCode.J)) StartGearShift(KeyCode.J, neutral1_2);
        if (Input.GetKeyDown(KeyCode.K)) StartGearShift(KeyCode.K, neutral3_4);
        if (Input.GetKeyDown(KeyCode.L)) StartGearShift(KeyCode.L, neutral5_R);
        if (Input.GetKeyDown(KeyCode.M)) StartGearShift(KeyCode.M, gear2);
        if (Input.GetKeyDown(KeyCode.Comma)) StartGearShift(KeyCode.Comma, gear4);
        if (Input.GetKeyDown(KeyCode.Period)) StartGearShift(KeyCode.Period, reverse);
    }

    void StartGearShift(KeyCode gearKey, Transform target)
    {
        currentGearKey = gearKey;
        targetGear = target;
        StartCoroutine(ShiftGear());
    }

    IEnumerator ShiftGear()
    {
        isShifting = true;
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetGear.position);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, targetGear.position) > shiftThreshold)
        {
            if (!Input.GetKey(currentGearKey) || !isClutchEngaged)
            {
                // Cancel shift if key or clutch is released
                StartCoroutine(AbortShift(startPosition));
                yield break;
            }

            float distCovered = (Time.time - startTime) * shiftSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetGear.position, fractionOfJourney);
            yield return null;
        }

        CompleteShift();
    }

    IEnumerator AbortShift(Vector3 returnPosition)
    {
        while (Vector3.Distance(transform.position, returnPosition) > shiftThreshold)
        {
            transform.position = Vector3.Lerp(transform.position, returnPosition, shiftSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = returnPosition;
        isShifting = false;
    }

    void CompleteShift()
    {
        transform.position = targetGear.position;
        isShifting = false;
    }
}
