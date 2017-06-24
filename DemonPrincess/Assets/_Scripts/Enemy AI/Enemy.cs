using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    //Declare Objects
    public GameObject gamoPlayer;
    public NavMeshAgent nav;
    public Animator anim;
    public Rigidbody rbody;
    public AnimationClip animAttack;
    protected float floDetectionDistance { get; set; }
    protected float floPreviousAngle = 0f;
    protected float previousAngularVelocity;
    protected float previousVelocity;

    //Declare SM Objects
    EnemySMInterface IsWandering;
    EnemySMInterface IsAttacking;
    EnemySMInterface IsDead;
    EnemySMInterface IsIdle;
    EnemySMInterface IsPursuing;
    EnemySMInterface emCurrent;


    //Constructor
    public Enemy()
    {
        //Create Interface Options at Construction
        IsWandering = new EnemyS_Wandering(this);
        IsAttacking = new EnemyS_Attacking(this);
        IsDead = new EnemyS_Dead(this);
        IsIdle = new EnemyS_Idle(this);
        IsPursuing = new EnemyS_Pursuing(this);
        //Set Current State
        emCurrent = IsIdle;
        StartIdle();
    }


    //------------------------------------------------------------------------------
    protected virtual void Awake()
    {
        //Find and Set Player object via a foreach loop
        //Setup Nav Mesh Agent object using getComponent Method
        foreach (GameObject gamo in FindObjectsOfType<GameObject>())
        {
            if (gamo.name.Equals("Princess"))
            { gamoPlayer = gamo; }
        }

        //foreach (ParticleSystem psys in FindObjectsOfType<ParticleSystem>())
        //{
        //    if (psys.name.Equals("Blood Attack")) { psysBloodAttack = psys; }
        //}

        nav = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        rbody = gameObject.GetComponent<Rigidbody>();

        floDetectionDistance = 10;

    }//End Awake Method

    //private void Update()
    //{
    //}

    //------------------------------------------------------------------------------

    protected void FixedUpdate()
    {

        float floDist = Vector3.Distance(transform.position, gamoPlayer.transform.position);
        if (floDist <= floDetectionDistance)
        {
            //Debug.Log(floDist.ToString());
            PlayerSpotted(floDist);
        }
        else
        {
            if (emCurrent == IsAttacking ||
               emCurrent == IsPursuing)
            {
                StartIdle();
            }
            else if (emCurrent == IsIdle)
            {
                StartWandering();
            }
        }



        //float angleOfVelocity = Mathf.Atan2(nav.velocity.z, nav.velocity.x) * Mathf.Rad2Deg;
        float angleOfCharacterForward = Mathf.Atan2(transform.forward.z, transform.forward.x) * Mathf.Rad2Deg;
        //float angleBetween = angleOfVelocity - angleOfCharacterForward;
        //Debug.Log("Angle character should rotate is " + angleBetween);
        //float amountToTurn = angleBetween / 30;
        //amountToTurn = Mathf.Clamp(amountToTurn, -1f, 1);
        float angularVelocity = (angleOfCharacterForward - floPreviousAngle) / Time.fixedDeltaTime;
        //normalize
        angularVelocity /= 180f;
        angularVelocity = (previousAngularVelocity * 3 + angularVelocity) / 4f;
        anim.SetFloat("Turn", angularVelocity);
        //Debug.Log(angularVelocity.ToString());

        floPreviousAngle = angleOfCharacterForward;

        //Debug.Log(nav.velocity);
        //if (nav.velocity.magnitude > .15)
        //{
        anim.SetFloat("Forward", nav.velocity.magnitude / 4f);

        //}
        //else
        //{
        //    anim.SetFloat("Forward", 0f);
        //}



    }

   
    //------------------------------------------------------------------------------

    protected virtual void PlayerSpotted(float floCurDist)
    {
        if (floCurDist <= 2) { StartAttacking(); } else { StartPursuit(); }
    }

    //************************ BEGIN SM SET/GET METHODS ****************************
    //------------------------------------------------------------------------------
    //Set Current Status
    public void SetEnemyState(EnemySMInterface newState)
    { emCurrent = newState; }//End Set Enemy Movement State

    //------------------------------------------------------------------------------

    //Methods to pass state changes
    public void StartWandering() { emCurrent.IsWandering(); } //intCounter++; Debug.Log("Moving - " + intCounter.ToString()); 
    public void StartAttacking() { emCurrent.IsAttacking(); } //intCounter++; Debug.Log("Attacking - " + intCounter.ToString()); 
    public void StartIdle() { emCurrent.IsIdle(); } //intCounter++; Debug.Log("Idle - " + intCounter.ToString()); 
    public void StartDeathSet() { emCurrent.IsDead(); } // intCounter++; Debug.Log("Death - " + intCounter.ToString()); 
    public void StartPursuit() { emCurrent.IsPursuing(); } // intCounter++; Debug.Log("Pursuit - " + intCounter.ToString()); 

    //------------------------------------------------------------------------------

    //Methods to get Statuses
    public EnemySMInterface getIsMoving() { return IsWandering; }
    public EnemySMInterface getIsAttacking() { return IsAttacking; }
    public EnemySMInterface getIsIdle() { return IsIdle; }
    public EnemySMInterface getIsDeathSet() { return IsDead; }
    public EnemySMInterface getIsPursuing() { return IsPursuing; }

    //------------------------------------------------------------------------------
    //************************* END SM SET/GET METHODS *****************************


    //************************** BEGIN STATE HANDLERS ******************************

    public virtual IEnumerator IHandleAttack()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(animAttack.length);
        //anim.SetBool("Attack", false);
        StartIdle();
    }

    //------------------------------------------------------------------------------

    public virtual void HandleWandering()
    {
        Vector3 v3Rot = new Vector3(0, Random.Range(0f, 60f), 0);
        float floRnd = Random.Range(0f, 10f);
        transform.Rotate(v3Rot, Space.Self);
        Vector3 v3Cur = transform.position;
        if (floRnd > 6)
        {
            nav.destination = new Vector3(v3Cur.x + Random.Range(-2f, 2f), 0f, v3Cur.z + Random.Range(-2f, 2f));
        }
        StartCoroutine(IHandleLostPlayer(floRnd));
    }

    //------------------------------------------------------------------------------

    //Methods to pursue player
    public void PursuePlayer() { nav.destination = gamoPlayer.transform.position; }
    public void HandleAttacking() { StartCoroutine(IHandleAttack()); }
    public void HandleLostPlayer() { StartCoroutine(IHandleLostPlayer()); }
    //------------------------------------------------------------------------------

    public virtual IEnumerator IHandleLostPlayer(float floTime = 5f)
    {
        GetComponent<Rigidbody>().velocity.Set(0f, 0f, 0f);
        yield return new WaitForSeconds(floTime);
        StartWandering();
    }

    //------------------------------------------------------------------------------

    //Method to start death sequence of Enemy
    public void KillThisEnemy()
    {
        Debug.Log("Killing Enemy...");
        StartCoroutine(IHandleEnemyDeath());
    }
    //------------------------------------------------------------------------------

    public virtual IEnumerator IHandleEnemyDeath()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
    }

    //------------------------------------------------------------------------------



    //*************************** END STATE HANDLERS *******************************



}
