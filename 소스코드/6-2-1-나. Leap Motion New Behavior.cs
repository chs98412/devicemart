using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class NewBehaviourScript : MonoBehaviour
{

   
    Controller controller;
    float HandPalmPitch;
    float HandPalmRoll;
    float HandPalmYam;
    float HandWristRot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        controller = new Controller();
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;
        if (frame.Hands.Count > 0)
        {
            Hand fristHand = hands[0];
        }

        HandPalmPitch = hands[0].PalmNormal.Pitch;
        HandPalmRoll = hands[0].PalmNormal.Roll;
        HandPalmYam = hands[0].PalmNormal.Yaw;

        HandWristRot = hands[0].WristPosition.Pitch;

        Debug.Log("Pitch : " + HandPalmPitch);
        Debug.Log("Roll : " + HandPalmRoll);
        Debug.Log("Yam : " + HandPalmYam);

        if (HandPalmYam > -2f && HandPalmYam < 3.5f && (frame.Hands[1].GrabStrength==1.0 ))
        {
            Debug.Log("앞");
            //this.transform.Translate(0,  1 * Time.deltaTime,0);
            this.transform.Translate(0,  2 * Time.deltaTime,0);
        }
        this.transform.Rotate(0, 30, 0);

        if ((frame.Hands[1].GrabStrength == 1.0) && (frame.Hands[0].GrabStrength == 1.0))
            Destroy(gameObject);

    }
}