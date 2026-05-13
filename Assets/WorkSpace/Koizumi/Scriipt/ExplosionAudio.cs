using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour
{
    [SerializeField]
    // 爆発音オブジェクト
    private GameObject m_explodeAudioObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ProgressCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int getSubEmitterParticleNum()
    {
        int ptNum = 0;
        ParticleSystem[] psArr = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in psArr)
        {
            ptNum += ps.particleCount;
        }
        return ptNum;
    }

    IEnumerator ProgressCo()
    {
      
        // 爆発待ち
        while (getSubEmitterParticleNum() == 0)
        {
            yield return null;
        }
        // 爆発音
        m_explodeAudioObj.GetComponent<AudioSource>().pitch *= Random.Range(0.8f, 1.2f);
        m_explodeAudioObj.GetComponent<AudioSource>().Play();
        // 消滅待ち
        while (getSubEmitterParticleNum() > 0)
        {
            yield return null;
        }
        // 消滅
        Destroy(gameObject);
    }
}
