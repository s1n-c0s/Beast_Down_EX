using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public static int attack_and_defens = 0;
    public static int dodge = 0;
    public static int type = 0;//0 = N ,1 = P ,2 = S , 3 = I
    public static int heal = 0;
    public static bool speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("attack_and_defens : " + attack_and_defens);
        }
    }
}
