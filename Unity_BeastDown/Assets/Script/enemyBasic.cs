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

                if (!speed || playerDamage.speed)
                {
                    if (playerDamage.attack_and_defens > 0)
                    {
                        if (lost_type == playerDamage.type)
                        {
                            HPenemy = HPenemy - (playerDamage.attack_and_defens * 2 * playerDamage.Lmultiply) + playerDamage.Lplus;
                        }
                        else if (lost_type != playerDamage.type)
                        {
                            HPenemy = HPenemy - (playerDamage.attack_and_defens * playerDamage.Lmultiply) + playerDamage.Lplus;
                        }
                    }//เป็นการ์ดโจมตีหรือป้องกัน
                    if (playerDamage.dodge > HPenemy)
                    {
                        HPenemy = 0;
                    }//เป็นการ์ดหลบ
                }//มอนที่ไม่ใช่แบบเร็ว หรือเราใช้การ์ดเร็ว

                if (playerDamage.heal > 0)
                {
                    MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                    HPenemy = 0;
                    MainCharacterScript.HP = MainCharacterScript.HP + (playerDamage.heal * playerDamage.Lmultiply) + playerDamage.Lplus;
                }//เป็นการ์ดรักษา หมายเหตุ โดนตีก่อนถึงรักษา

                if (HPenemy > 0)
                {
                    MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                }//ถ้ามอนไม่ตาย


                playerDamage.Lattack_and_defens = playerDamage.attack_and_defens;
                playerDamage.Ldodge = playerDamage.dodge;
                playerDamage.Ltype = playerDamage.type;
                playerDamage.Lheal = playerDamage.heal;
                playerDamage.Lspeed = playerDamage.speed;                               //เก็บค่าล่าสุด

                playerDamage.Lplus = playerDamage.plus;
                playerDamage.Lmultiply = playerDamage.multiply;                         //เก็บค่าพิเศษ                   

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("attack_can_do : " + ((playerDamage.attack_and_defens * playerDamage.Lmultiply) + playerDamage.Lplus));
        }
        
    }
}
