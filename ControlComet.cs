using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlComet : MonoBehaviour
{
    [SerializeField] float rotateSpeed;//ช่องใส่ความเร็วการหมุน
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.World);//การหมุนของวัตถุแกน z
    }
    private void OnTriggerEnter2D(Collider2D collision)//เมื่อวัตถุมีการชน
    {
        if(collision.gameObject.CompareTag("player"))//ถ้ามีการชนกับวัตถุที่มี tag player
        {
            Destroy(gameObject);//ทำลายวัตถุ
            HP.HPShip -=1;//เลือดผู้เล่นลดลง 1
        }
        if (collision.gameObject.CompareTag("Bullet"))//ถ้ามีการชนกับวัตถุที่มี tag Bullet
        {
            HP.Score +=5;//คะแนนผู้เล่นเพิ่มขึ้น 5
            Destroy(gameObject);//ทำลายวัตถุ
        }
    }
}
