using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public int HPenemy = 6;
    bool die = false;
    public int lost_type;
    public bool speed = false;

    public GameObject enemywilldie;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (play_cards.sequenceCardOneToFive[0] == 0 && play_cards.sequenceCardOneToFive[1] == 0 && play_cards.sequenceCardOneToFive[2] == 0
                && play_cards.sequenceCardOneToFive[3] == 0 && play_cards.sequenceCardOneToFive[4] == 0 && die == false)//ไม่ได้เลือกการ์ด
            {

                MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                die = true;
                Destroy(enemywilldie, 0.5f);
            }
            else if ((play_cards.sequenceCardOneToFive[0] != 0 || play_cards.sequenceCardOneToFive[1] != 0 || play_cards.sequenceCardOneToFive[2] != 0
                || play_cards.sequenceCardOneToFive[3] != 0 || play_cards.sequenceCardOneToFive[4] != 0) && die == false)
            {
                play_cards.willruncard = true;

                if (playerDamage.attack_and_defens > 0)
                {
                    if (lost_type == playerDamage.type)
                    {
                        HPenemy = HPenemy - (playerDamage.attack_and_defens * 2);
                    }
                    else if (lost_type != playerDamage.type)
                    {
                        HPenemy = HPenemy - playerDamage.attack_and_defens;
                    }
                }//เป็นการ์ดโจมตี
                else if (playerDamage.dodge > HPenemy)
                {
                    HPenemy = 0;
                }//เป็นการ์ดหลบ
                else if (playerDamage.heal > 0)
                {
                    MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                    HPenemy = 0;
                    MainCharacterScript.HP = MainCharacterScript.HP + playerDamage.heal;
                }//เป็นการ์ดรักษา หมายเหตุ โดนตีก่อนถึงรักษา

                if (HPenemy > 0)
                {
                    MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                }

                playerDamage.attack_and_defens = 0;

                die = true;
                Destroy(enemywilldie, 0.5f);
            }
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
