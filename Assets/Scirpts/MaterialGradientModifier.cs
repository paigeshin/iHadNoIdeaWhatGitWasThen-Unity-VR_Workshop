using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Renderer))] //안정성을 높여준다. This class requires Renderer. 이러한 것들을 Attribute라고 한다.
public class MaterialGradientModifier : MonoBehaviour
{
    Renderer _renderer; //first way to get Component.
    [SerializeField] Gradient gradient;

    float _gradientPosition;
    public float gradientPosition
    {
        get { return _gradientPosition; }
        set
        {
            if(_gradientPosition != value)
            {
                _gradientPosition = value;
                _renderer.material.color = gradient.Evaluate(_gradientPosition);
            }
        }
    }

    //Change the Value here
    //void SetGradientPosition(float position)
    //{
        //if (position == gradientPosition) 
            //position과 gradientPosition 값이 같으면 gradient가 아니기 때문에 막아놓음.
            //return;

        //gradientPosition = position;
        //_renderer.material.color = gradient.Evaluate(gradientPosition);
        //first way to get Component. --- Evaluate를 하면 이미 gradient 객체가 형성된것이다. 파라미터는 초기 설정값인듯 하다.
    //}

    void Awake() //this method is called before unity starts 
    {
        _renderer = GetComponent<Renderer>(); 
        //Second Way to get the Component 
        //It's going to take an Object from the same object where the script exists.
    }

    // Start is called before the first frame update
    void Start() //It's a message sending to monoBehaviour 
    {
        gradientPosition = 0;
        //SetGradientPosition(0);
    }

    // Update is called once per frame
    //void Update()
    //{
        //gradientPosition = Mathf.Sin(((Time.time)) * 0.5f) + 0.5f;
        //SetGradientPosition((Mathf.Sin(Time.time) * 0.5f) + 0.5f);
    //}


}
