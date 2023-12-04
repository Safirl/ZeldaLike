using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] AudioManager m_audioManager;
    [SerializeField] GameManager m_gameManager;
    private bool isWarMusicPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<AudioManager>() != null)
        {
            m_audioManager = gameObject.GetComponent<AudioManager>();
        }
        if (FindObjectOfType<GameManager>() != null)
        {
            m_gameManager = FindObjectOfType<GameManager>();
        }
        m_audioManager.PlayMusicChill(m_audioManager.m_clip, true);
        isWarMusicPlaying = false;

    }

    // Update is called once per frame
    void Update()
    {
        ChangeMusic();
        gameObject.GetComponent<AudioSource>().volume = 0.1f;
    }

    public void ChangeMusic()
    {
        //S'il n'y a pas d'ennemis c'est true
        if (m_gameManager.GetEnemiesAlive())
        {
            if (isWarMusicPlaying)
            {
                m_audioManager.PlayMusicChill(m_audioManager.m_clip, true);
                isWarMusicPlaying = false;
            }

        }
        else
        {
            if (!isWarMusicPlaying)
            {
                m_audioManager.PlayMusicWar(m_audioManager.m_clip1, true);
                isWarMusicPlaying = true;

            }
        }
    }
}
