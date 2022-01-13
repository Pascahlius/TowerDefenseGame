using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    private float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float shakeSaveDurationValue = 0.0f;
    public static CameraShake instance;

    Vector3 originalPos;

    private void Awake()
    {
        instance = this;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void StartShake()
    {
        shakeDuration = shakeSaveDurationValue;
        originalPos = camTransform.localPosition;
    }
}
