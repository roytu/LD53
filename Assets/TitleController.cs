using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public GameObject VeryGood;
    public GameObject Happy;
    public GameObject JoyPlay;
    public GameObject ThreeThousand;
    public Image Background;
    public GameObject PressSpace;

    Vector3 start = new Vector3(0f, 100f, 0f);

    private List<Vector3> origins;

    private float t = 0;
    private float delay = 1f;

    private float partyTimer = 0f;
    private float flashDelay = 0.2f;
    private float spaceDelay = 1.5f;

    private AudioSource audioSource;
    public AudioClip orchestraClip;
    public AudioClip yayClip;
    private bool didYay = false;
    void Start()
    {
        origins = new List<Vector3>();
        origins.Add(VeryGood.transform.position);
        origins.Add(Happy.transform.position);
        origins.Add(JoyPlay.transform.position);
        origins.Add(ThreeThousand.transform.position);

        VeryGood.transform.position = start;
        Happy.transform.position = start;
        JoyPlay.transform.position = start;
        ThreeThousand.transform.position = start;

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(orchestraClip);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > delay * 0) {
            Ease(VeryGood, origins[0]);
        }
        if (t > delay * 1) {
            Ease(Happy, origins[1]);
        }
        if (t > delay * 2) {
            Ease(JoyPlay, origins[2]);
        }
        if (t > delay * 3) {
            Ease(ThreeThousand, origins[3]);
        }
        if (t > delay * 4) {
            if (!didYay)
            {
                didYay = true;
                audioSource.PlayOneShot(yayClip);
            }
            partyTimer += Time.deltaTime;
            if ((partyTimer % flashDelay) > (flashDelay / 2))
            {
                Background.color = new Color(0.949f, 1f, 0.514f);
            }
            else
            {
                Background.color = new Color(0.973f, 1f, 0.757f);
            }

            if ((partyTimer % spaceDelay) > (spaceDelay / 2))
            {
                PressSpace.SetActive(true);
            }
            else
            {
                PressSpace.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameSelectScene");
        }
    }

    void Ease(GameObject obj, Vector3 origin)
    {
        float ry = obj.transform.position.y;
        float oy = origin.y;

        float ny = (ry + oy) / 2f;
        obj.transform.position = new Vector3(
            obj.transform.position.x,
            ny,
            obj.transform.position.z
        );
    }

}
