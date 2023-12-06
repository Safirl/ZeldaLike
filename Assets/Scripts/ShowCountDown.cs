using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowCountDown : MonoBehaviour
{
    [SerializeField] private Text text;
    WaveManager m_waveManager;
    [SerializeField] protected Image m_CountDownBar;




    // Start is called before the first frame update
    void Awake()
    {
        m_waveManager = FindObjectOfType<WaveManager>().GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_CountDownBar.fillAmount = m_waveManager.getHoldKeyCountDown() / 3.3f;
    }

    public void ShowWaveCountDown(bool show)
    {
        if (show)
        {
            text.gameObject.SetActive(true);
            m_CountDownBar.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            text.gameObject.SetActive(false);
            m_CountDownBar.transform.parent.gameObject.SetActive(false);
        }
    }
}
