using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] KeyCode keyCodeAttck = KeyCode.Space;
    [SerializeField] GameObject bullet;
    Movement movement;
    Weapon weapon;
    Animator anim;
    bool isDie = false;

    int score;

    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
        /*get { return score; }
        set
        {
            if(value < 0)
                score = 0;
            else
                score = value;
        }*/
    }

    void Start()
    {
        movement = GetComponent<Movement>();
        weapon = GetComponent<Weapon>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDie) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movement.MoveTo(new Vector3(h, v, 0));

        if (Input.GetKeyDown(keyCodeAttck))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttck))
        {
            weapon.StopFiring();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y),
            0);
    }
    
    public void Die()
    {
        movement.MoveTo(Vector2.zero);
        anim.SetTrigger("onDie");
        Destroy(GetComponent<CircleCollider2D>());
        isDie = true;
    }

    public void OnDieEvent()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");
    }
}
