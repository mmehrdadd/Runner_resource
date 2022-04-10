using UnityEngine;
using Cinemachine;
public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    private float shakeTime;
    public static CinemachineShake instanse { get; private set; }
    private void Awake()
    {
        instanse = this;
        vCam = GetComponent<CinemachineVirtualCamera>();
    }
    public void CameraShake(float intensity, float duration)
    {
        Debug.Log("called");
        CinemachineBasicMultiChannelPerlin shakeEffect =
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        shakeEffect.m_AmplitudeGain = intensity;
        shakeTime = duration;
    }

    private void Update()
    {
        Debug.Log(shakeTime);
         if(shakeTime > 0)
            shakeTime -= Time.deltaTime;

        if (shakeTime <= 0)
        {
            Debug.Log("shake 0");
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }
}
