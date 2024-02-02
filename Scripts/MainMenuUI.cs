using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource aD;
    [SerializeField] private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
 
        mainMenu.SetActive(true);

        howToPlay.SetActive(false);
        credits.SetActive(false);
    }

    void Update()
    {
        
    }


    public void HotToPlayBtnClicked()
    {
        SoundUI();
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);   
    }
    public void CreditsBtnClicked()
    {
        SoundUI();
        mainMenu.SetActive(false);
        credits.SetActive(true);
    } 

    public void BackBtnClicked()
    {
        SoundUI();
    

        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
        credits.SetActive(false);
    }

    public void PlayBtnClicked()
    {
        SoundUI();
        StartCoroutine(DelayLevel());
      
    }

    IEnumerator DelayLevel()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Cal");
    }

    private void SoundUI()
    {
        aD.PlayOneShot(audioClip);
    }


}
