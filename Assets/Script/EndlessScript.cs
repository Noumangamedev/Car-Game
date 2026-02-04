using UnityEngine;

public class EndlessScript : MonoBehaviour
{
    [SerializeField]private Transform playerCarTransform;
    [SerializeField]private  Transform otherCityTransform;
    [SerializeField]private float halfLenght=0f;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCarTransform.position.z > transform.position.z+halfLenght+10f)
        {
            transform.position = new Vector3(0,0,otherCityTransform.position.z + halfLenght * 2);
          
        }
    }
}
