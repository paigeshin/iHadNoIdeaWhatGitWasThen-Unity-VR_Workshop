using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocus : MonoBehaviour
{
    [SerializeField] Transform reference; //카메라 위치를 참조한다.

    [SerializeField] float minAngle = 10;
    [SerializeField] float maxAngle = 30;
    

    private float _fadeAmount = -1;
    public float fadeAmount
    {
        get { return _fadeAmount; }
        set
        {
            if(value != fadeAmount)
            {
                _fadeAmount = value;
            }
        }
    }

    private float _delta = -1; //_fadeAmount와 값을 비교하기 위해 만든 변수.   measure the angle and the distance.
    public float delta
    {
        get { return _delta; }
        set
        {
            if(value != _delta)
            {
                _delta = value;
                // TODO : Update Fade Amount Value.
                //FadeAmount.
                fadeAmount = Mathf.Lerp(maxAngle, minAngle, _delta);  //Lerp - interpolate - 중간값을 채움.
            }
        }
    }

    void Fade()
    {
        // TODO : Update Delta
        //Debug.DrawLine(reference.position, transform.position, Color.yellow);   //여기서 reference는 카메라인거 알지? ㅎ
    
        Vector3 distance = (transform.position - reference.position).normalized; //현재위치와 카메라위치를 빼줌. 즉 거리를 구함, //Normalized -- x,y,z position 값을 일정하게 만든다.
        Debug.DrawRay(reference.position, reference.forward, Color.cyan);  //forwoard direction. what camera's looking into.
        Debug.DrawRay(reference.position, distance, Color.yellow);
        delta = Vector3.Angle(distance, reference.forward);
    }

   
    // Start is called before the first frame update
    void Awake()
    {
        //reference = GameObject.FindGameObjectWithTag("MainCamera").transform;                  --this is the one way
        if (reference == null) { 
            reference = Camera.main.transform;  //Another way to reference camera position.
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fade();
    }

    //Useful way to program graphically 
    void OnGUI()
    {
        GUILayout.Label("delta : " + delta.ToString());
        GUILayout.Label("fadeAmount : " + fadeAmount.ToString());
    }
}
