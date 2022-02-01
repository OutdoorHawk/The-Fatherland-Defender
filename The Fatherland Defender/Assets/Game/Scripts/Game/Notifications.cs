using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
   

    [SerializeField] private GameObject _getReadyText;
    [SerializeField] private GameObject _noMoneyText;
    [SerializeField] private GameObject _clearWaveText;

    [SerializeField] private Text _clearBonusAmount;

    private Animator _anim;

   

  


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

 

    public void ClearWaveBonus(int moneyForClearWave)
    {
        _clearBonusAmount.text = "$" + moneyForClearWave.ToString();
        _clearWaveText.SetActive(true);
        _anim.SetTrigger("ClearWave");
       
    }





    private void NotificationsOff()
    {
        _clearWaveText.SetActive(false);
        _noMoneyText.SetActive(false);
            _getReadyText.SetActive(false);
        
    }

}
