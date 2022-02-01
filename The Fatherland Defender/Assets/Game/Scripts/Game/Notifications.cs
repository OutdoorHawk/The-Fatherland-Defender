using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private GameObject _getReadyText;
    [SerializeField] private GameObject _noMoneyText;

    [SerializeField] private Vector3 _notificationSpawnPosition;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        GetReady();
    }

    public void NoMoney()
    {
       



        _noMoneyText.SetActive(true);
        _anim.SetTrigger("NoMoney");
       
    }

    private void GetReady()
    {
        _getReadyText.SetActive(true);
       _anim.SetTrigger("GetReady");

       // _anim.SetBool("Get Ready", true);



    }

   


    private void NotificationsOff()
    {
        _noMoneyText.SetActive(false);
            _getReadyText.SetActive(false);
        
    }

}
