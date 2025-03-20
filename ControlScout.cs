using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScout : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))//ตรวจสอบเมื่อชนกับวัตถุที่มี tag player
        {
            Destroy(gameObject);//ทำลายวัตถุ
            HP.HPShip -=5;//เลือดยานของผู้เล่นลดลง 5 
        }
        if (collision.gameObject.CompareTag("Bullet"))//ตรวจสอบเมื่อชนกับวัตถุที่มี tag Bullet
        { 
            if(HP.HPShip >= 100)//ถ้าเลือดยานของผู้เล่นมีมากกว่าหรือเท่ากับ 100
                {
                    HP.HPShip +=0;//เลือดยานของผู้เล่นจะเพิ่มขึ้น 0 
                    HP.Score +=10;//คะแนนผู้เล่นเพิ่มขึ้น 10
                    Destroy(gameObject);//ทำลายวัตถุ
                    PlayerControl.fireRate -= 0.1f;//ทำให้ความเร็วในการยิงของผู้เล่นเพิ่มขึ้น
                }
            if(HP.HPShip < 100)
                {
                    HP.Score +=10;//คะแนนผู้เล่นเพิ่มขึ้น 10
                    HP.HPShip +=5;//เลือดยานของผู้เล่นจะเพิ่มขึ้น 5
                    Destroy(gameObject);//ทำลายวัตถุ
                    PlayerControl.fireRate -= 0.1f;//ทำให้ความเร็วในการยิงของผู้เล่นเพิ่มขึ้น
                }
            
        }
    }
}
