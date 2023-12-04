/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes) and MMI Teaching (IUT Bordeaux Montaigne)
 *
 * This work is licensed under the CC0 License.
 *
 */

using UnityEngine;
using System.Collections;
//using UnityEditorInternal;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance = null;
	[Header("AudioSource")]
	public AudioSource m_soundStream;
	public AudioSource m_musicStreamChill;
    public AudioSource m_audioStreamWar;

    [Header("Clip")]

    public AudioClip m_clip;
    public AudioClip m_clip1;
    public AudioClip m_clip2;

 

/*	void Awake() {
		if (instance == null) {
			instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
			Destroy (gameObject);
		}
	}*/

	public void PlaySound(AudioClip soundClipToPlay, float volume = 1.0f, float pitch = 1.0f) {
		m_soundStream.pitch = pitch;
		m_soundStream.volume = volume;
		m_soundStream.clip = soundClipToPlay;
		m_soundStream.Play();
	}

    public void StopSound()
    {
        m_soundStream.Stop();
    }

    public void PlayMusicChill(AudioClip musicClipToPlay, bool mustLoop, float volume = 1.0f, float pitch = 1.0f)
    {
        m_musicStreamChill.pitch = pitch;
        m_musicStreamChill.volume = volume;
        m_musicStreamChill.loop = mustLoop;
        m_musicStreamChill.clip = musicClipToPlay;
        m_musicStreamChill.Play();
    }

    public void StopMusicChill() {
        m_musicStreamChill.Stop();
	}
    public void PlayMusicWar(AudioClip musicClipToPlay, bool mustLoop, float volume = 1.0f, float pitch = 1.0f)
    {
        m_audioStreamWar.pitch = pitch;
        m_audioStreamWar.volume = volume;
        m_audioStreamWar.loop = mustLoop;
        m_audioStreamWar.clip = musicClipToPlay;
        m_audioStreamWar.Play();
    }

    public void StopMusicWar()
    {
        m_audioStreamWar.Stop();
    }

}

