using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

enum State {
    NotStarted,
    Instructions,
    Playing,
    BabbyFormed,
    Paternity
}

State state = State.NotStarted;
public GameObject goSpace;
public PlayableDirector vial;
public SpriteRenderer goObjective;
public Sprite babbyFormedSprite;
public Animator goWinFail;
public Animator hand;
public GameObject prefabDrop;
public AudioSource music;
public Transform dropSpawn;
public float timer = 0;
public BbJuice bbJuice;
public GameObject paternity;
public AudioSource babyCry;

void Awake()
{
    ChangeState(State.NotStarted);
}
void ChangeState(State state)
{
    this.state = state;
    Debug.Log(state);
    switch (state)
    {
        case State.NotStarted:
            bbJuice.gameObject.SetActive(false);
            paternity.SetActive(false);
            music.Play();
            goObjective.gameObject.SetActive(true);
            goWinFail.gameObject.SetActive(false);
            goSpace.SetActive(false);
            //hand.speed = 0;
            break;
        case State.Instructions:
            goObjective.gameObject.SetActive(false);
            goSpace.SetActive(true);
            break;
        case State.Playing:
            goSpace.SetActive(false);
            break;
        case State.BabbyFormed:
            goObjective.gameObject.SetActive(true);
            bbJuice.gameObject.SetActive(false);
            goObjective.sprite = babbyFormedSprite;
            timer = 0;
            break;
        case State.Paternity:
            babyCry.Play();
            goObjective.gameObject.SetActive(false);
            paternity.SetActive(true);
            break;
    }
}

void Update()
{
    if (state == State.NotStarted && timer > 3f)
    {
        timer = 0;
        ChangeState(State.Instructions);
    }
    if (state == State.Instructions && timer > 3f)
    {
        timer = 0;
        ChangeState(State.Playing);
    }

    if (state == State.Playing)
    {
        int drops = vial.gameObject.GetComponent<Vial>().maxNumDrops;
        if (drops > 0)
        {
            bbJuice.gameObject.SetActive(true);
            bbJuice.SetNum(drops);
        }

        if (drops >= 5)
        {
            ChangeState(State.BabbyFormed);
        }
    }

    if (state == State.BabbyFormed && timer > 3f)
    {
        ChangeState(State.Paternity);
    }

    timer += Time.deltaTime;
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Object.Instantiate(prefabDrop, dropSpawn);
        hand.SetTrigger("Drop");
    }
}
}
