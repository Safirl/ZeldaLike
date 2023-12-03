using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_renderer;
    [SerializeField] private Collider2D m_collider;
    private bool isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor(bool open)
    {
        //PlaySound
        if (open)
        {
            isDoorOpen = true;
            m_renderer.sprite = null;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
        else
            gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log(collider.gameObject.tag);

        if (collider.gameObject.tag == "Player")
        {
            Debug.Log(isDoorOpen);
            if (isDoorOpen)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
