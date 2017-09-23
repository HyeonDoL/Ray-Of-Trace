using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LandState
{
    Idle,
    Walk,
    Attack
}
public enum SkyState
{
    Walk,
    Attack
}
public class AI : MonoBehaviour {
  
  
    [SerializeField]
    private Animator MonsterAni;

    private LandState prevState = LandState.Idle;
    private SkyState prevState2 = SkyState.Walk;
    private Transform MonsterTrans;
    private Rigidbody2D MonsterRigid;
    private Vector3 SpawnPosition;
    private Vector3 PlayerPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpspeed;

    private float playerx;
    private float monsterx;
    private float dis;

    public int Monster;
    // Use this for initialization
    void Start () {
        MonsterTrans = this.GetComponent<Transform>();
        MonsterRigid = this.GetComponent<Rigidbody2D>();
        SpawnPosition = this.transform.position;
     

    }
	
	// Update is called once per frame
	void Update () {
        PlayerPos = IngameButtonManager.Instance.playerposition;
        playerx = PlayerPos.x;
        monsterx = this.transform.position.x;
        dis = Vector3.Distance(PlayerPos, this.transform.position);
        if (Monster == 1)
        {
            if (dis <= 1.5) //공격
            {
                ChangeLandAnimation(LandState.Attack);

            }
            else if (dis <= 7) // 추적
            {
                if (playerx > monsterx)
                {
                    ChangeLandAnimation(LandState.Walk);
                    Move(Vector3.right);
                    this.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    ChangeLandAnimation(LandState.Walk);
                    Move(Vector3.left);
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {

                ChangeLandAnimation(LandState.Idle);

            }
        }
        else if(Monster == 2)
        {
            if (dis <= 3) //공격
            {
                ChangeSkyAnimation(SkyState.Attack);

            }
            else if (dis <= 7) // 추적
            {
                if (playerx > monsterx)
                {
                    ChangeSkyAnimation(SkyState.Walk);
                    Move(Vector3.right);
                    this.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    ChangeSkyAnimation(SkyState.Walk);
                    Move(Vector3.left);
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {

                ChangeSkyAnimation(SkyState.Walk);

            }
        }
    }

   
    public void Move(Vector3 direction)
    {
        MonsterTrans.Translate(direction * speed * Time.deltaTime);
  
    }



    public void ChangeLandAnimation(LandState state)
    {
        if (prevState == state)
            return;

        MonsterAni.SetInteger("MonsterState", (int)state);
        
        prevState = state;
    }
    public void ChangeSkyAnimation(SkyState state)
    {
        if (prevState2 == state)
            return;

        MonsterAni.SetInteger("MonsterState", (int)state);

        prevState2 = state;
    }
}
