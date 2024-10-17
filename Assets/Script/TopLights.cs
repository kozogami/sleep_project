using UnityEngine;


public class ProcessBar : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;

    public float gameprogess;
    public float gameprogessSwitch;

    private float increment;
    private bool isStarted;


    public GameObject startPanel;
    public GameObject endPanel;



    void Awake()
    {
        slider.maxValue = 80;
        slider.value = 0;
        increment = 7f;

        gameprogess = 0;
        gameprogessSwitch = 0;


        isStarted = false;


        if (slider != null)
        {

            Debug.Log("TopLight in place.");
        }
        else
        {

            Debug.LogError("Error: Process Bar");
        }


}

    private void FixedUpdate()
    {
        if (endPanel.activeInHierarchy) {
            isStarted = false;
            return;
        }


        if (Input.GetKey(KeyCode.Space) && isStarted){

            slider.value += increment * 1 * Time.deltaTime;

        }

        else if (!Input.GetKey(KeyCode.Space) && slider.value > 0)
        {

            slider.value -= increment * 1 * Time.deltaTime;

        }



        if (!isStarted && Input.GetKey(KeyCode.Space)) {


            startPanel.SetActive(false);
            isStarted = true;

        }

    }

}
