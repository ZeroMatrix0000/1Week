using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerGauge : MonoBehaviour
{
    // パワーゲージの画像
    public Image m_powerGauge;
    // パワーの最大値
    public int m_maxPower;
    // パワー
    private int m_power;

    public ShowTimer m_shouTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_power = 0;
        m_powerGauge.fillAmount = (float)m_power / m_maxPower;
    }

    // Update is called once per frame
    void Update()
    {

        // タイマーがゼロになったら
        if (m_shouTimer.GetZeroCount())
        {
            return;
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            m_power++;
            m_powerGauge.fillAmount = (float)m_power / m_maxPower;


        }

        
    }
   
  

    // パワーの取得
    public int GetPower() {  return m_power; }
}
