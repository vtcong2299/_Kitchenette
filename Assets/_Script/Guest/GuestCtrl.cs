using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class GuestCtrl : MonoBehaviour
{
    [SerializeField]
    private GuestAnimation clientAnimation;
    [SerializeField]
    private GameObject targetPos;
    [SerializeField]
    private FoodDataSO food;
    [SerializeField]
    private GameObject think;
    [SerializeField]
    private float speedGuestRotate = 5;
    [SerializeField]
    private Quaternion currentTarget;
    [SerializeField]
    private GameObject targetDetroy;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private bool isHello;
    private void Awake()
    {
        clientAnimation = GetComponent<GuestAnimation>();
        currentTarget = Quaternion.LookRotation(Vector3.zero);
        int index = Random.Range(0, GameManager.instance.posNotHasGuest.Count - 1);
        targetPos = GameManager.instance.posNotHasGuest[index];
        GameManager.instance.ChangeListPos(index);
        GuestThink();
    }

    private void Update()
    {
        GuestMove();
    }
    public void GuestMove()
    {
        Quaternion targetRotation;
        if (Vector3.Distance(transform.position, targetPos.transform.position) < 0.05)
        {
            clientAnimation.SetAnimClientIdle();
            targetRotation = currentTarget;
            if (!think.activeSelf)
            {
                Destroy(gameObject);
            }
            if (!isHello)
            {
                SoundManager.instance.SoundHello();
                isHello = true;
            }
        }
        else
        {
            agent.SetDestination(targetPos.transform.position);
            targetRotation = Quaternion.LookRotation(targetPos.transform.position - transform.position);
            clientAnimation.SetAnimClientWalk();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedGuestRotate);
    }
    public void GuestThink()
    {
        int index = Random.Range(0, GameManager.instance.foodDataList.Count - 1);
        food = GameManager.instance.foodDataList[index];
        think.GetComponent<SpriteRenderer>().sprite = food.image;
    }
    public void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.position) > GameManager.instance.distance)
        {
            return;
        }
        if (!GameManager.instance.hasFoodInHand)
        {
            return;
        }
        if (GameManager.instance.foodSpawning.id != food.id)
        {
            return;
        }        
        GameManager.instance.OnClickGuest(food,targetPos);
        think.SetActive(false);
        targetPos = targetDetroy;
    }
}
