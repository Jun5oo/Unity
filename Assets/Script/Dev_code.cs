using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dev_code : MonoBehaviour
{
    public Transform target;  // ∏Ò«•
    public AnimationCurve parabolaCurve;
    public AnimationCurve axisCurve;

    public float moveSpeed;
    public float maxHeight;

    Vector3 startPoint;
    Vector3 range; 

    void Start()
    {
        startPoint = this.transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

 
    void Update()
    {
        UpdateMove();

        if (Vector3.Distance(this.transform.position, target.position) < 0.5f)
            Destroy(this.gameObject); 
    }

    private void UpdateRotation()
    {
        
    }

    void UpdateMove()
    {
        range = target.position - startPoint;
        
        if(Mathf.Abs(range.normalized.x) < Mathf.Abs(range.normalized.y))
        {

            // Projectile will be curved on the X axis 
            if(range.y < 0)
            {
                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed;
                }
            }


            UpdatePositionWithXCurve(); 
        }

     
        else
        {
            // Projectile will be curved on the Y axis 
            if (range.x < 0)
            {
                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed;
                }
            }

            UpdatePositionWithYCurve();
        }

    }

    private void UpdatePositionWithXCurve()
    {
        float nextPositionY = transform.position.y + moveSpeed * Time.deltaTime;
        float nextPositionYNormalized = (nextPositionY - startPoint.y) / range.y;

        float nextPositionXNormalized = parabolaCurve.Evaluate(nextPositionYNormalized);
        float nextPositionXCorrectionNormalized = axisCurve.Evaluate(nextPositionYNormalized);
        float nextPositionXCorrectAbsolute = nextPositionXCorrectionNormalized * range.x;

        float nextPositionX = startPoint.x + nextPositionXNormalized * maxHeight + nextPositionXCorrectAbsolute;
        Vector3 newPos = new Vector3(nextPositionX, nextPositionY);

        this.transform.position = newPos;
    }

    private void UpdatePositionWithYCurve()
    {
        float nextPositionX = transform.position.x + moveSpeed * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - startPoint.x) / range.x;

        float nextPositionYNormalized = parabolaCurve.Evaluate(nextPositionXNormalized);
        float nextPositionYCorrectionNormalized = axisCurve.Evaluate(nextPositionXNormalized);
        float nextPositionYCorrectAbsolute = nextPositionYCorrectionNormalized * range.y;

        float nextPositionY = startPoint.y + nextPositionYNormalized * maxHeight + nextPositionYCorrectAbsolute;

        Vector3 newPos = new Vector3(nextPositionX, nextPositionY);

        this.transform.position = newPos;
    }
}


