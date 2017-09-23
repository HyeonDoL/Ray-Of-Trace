using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Walk,
    Attack
}
public class AI : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    [SerializeField]
    private Animator MonsterAni;

    private MonsterState prevState = MonsterState.Idle;

    private Transform MonsterTrans;
    private Rigidbody2D MonsterRigid;
    private Vector3 SpawnPosition;
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpspeed;

    private float playerx;
    private float monsterx;
    private float dis;
    // Use this for initialization
    void Start () {
        MonsterTrans = this.GetComponent<Transform>();
        MonsterRigid = this.GetComponent<Rigidbody2D>();
        SpawnPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        playerx = Player.transform.position.x;
        monsterx = this.transform.position.x;
        dis = Vector3.Distance(Player.transform.position, this.transform.position);
	
        if (dis <= 1.5) //공격
        {
            ChangeAnimation(MonsterState.Attack);
          
        }
        else if (dis <= 7) // 추적
        {
            if (playerx > monsterx)
            {
                ChangeAnimation(MonsterState.Walk);
                Move(Vector3.right);
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                ChangeAnimation(MonsterState.Walk);
                Move(Vector3.left);
                this.transform.localScale = new Vector3(1, 1, 1);
            } 
        }
        else
        {
          
            ChangeAnimation(MonsterState.Idle);
       
        }
    }

   
    public void Move(Vector3 direction)
    {
        MonsterTrans.Translate(direction * speed * Time.deltaTime);
  
    }



    public void ChangeAnimation(MonsterState state)
    {
        if (prevState == state)
            return;

        MonsterAni.SetInteger("MonsterState", (int)state);
        
        prevState = state;
    }
}
