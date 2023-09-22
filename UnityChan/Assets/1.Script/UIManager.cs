using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject startButton;
    public GameObject jankenButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnEnable()
    {
        startButton.gameObject.SetActive(true);
        jankenButton.gameObject.SetActive(false);
        

    }

    private void disableAllButtons()
    {
        startButton.gameObject.SetActive(true);
        jankenButton.gameObject.SetActive(false);

    }

    public void EnableButton(Button _toEnable)
    {
        disableAllButtons();
        _toEnable.gameObject.SetActive(true);
    }
}
