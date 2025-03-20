using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    float playerInput; //ตัวแปรรับค่าจากผู้เล่นแกน x
    float playerInputY;//ตัวแปรรับค่าจากผู้เล่นแกน y
    float speed = 10;//ความเร็วการเคลื่อนที่
    public GameObject bulletPrefab;//ตัวแปรสำหรับใส่ prefeb กระสุน
    public float bulletSpeed = 10f;//ความเร็วเคลื่อนที่ของกระสุน
    public static float fireRate = 0.9f;//ความเร็วในการยิง
    private float nextFireTime = 0f;//ตัวหน่วงเวลาก่อนจะมีการยิงนัดถัดไปไม่ให้ถี่เกิน

    [SerializeField] AudioSource shoot;//ตัวแปรสำหรับใส่เสียง

    public GameObject reactionGroup;
    public TMP_Text Txt_HP;//โชว์เลือด
    public TMP_Text Txt_Score;//โชว์คะแนน

    void Update()
    {
        playerInput = Input.GetAxis("Horizontal")*speed;//ความเร็วเคลื่อนที่แนวนอน
        playerInputY = Input.GetAxis("Vertical") * speed;//ความเร็วเคลื่อนที่แนวตั้ง
        playerInput *= Time.deltaTime;//กำหนดความเร็วเป็นเวลา
        playerInputY *= Time.deltaTime;//กำหนดความเร็วเป็นเวลา
        transform.Translate(playerInput, 0, 0);//เคลื่อนที่แกน x
        transform.Translate(0, playerInputY, 0);//เคลื่อนที่แกน y

        Txt_HP.text = HP.HPShip.ToString();//ใส่ object Text เพื่อแสดงค่าเลือดของผู้เล่น
        Txt_Score.text = HP.Score.ToString();//ใส่ object Text เพื่อแสดงค่าคะแนน
        reactionGroup.SetActive(true);//คำสั้งแสดงค่าของ canvas

        if (Input.GetKey(KeyCode.Space)&& Time.time > nextFireTime)//ถ้าหากกดปุ่ม space bar 
        {
            ShootUp();//คำสั่งยิงขึ้นด้านบน
            nextFireTime = Time.time + fireRate;//หน่วงความเร็วในการยิง
        }
        if (HP.HPShip <= 0)//ถ้าหากเลือดน้อยกว่า 0 ให้ทำลายวัตุ
        {
            Destroy(gameObject);//ทำลายวัตุ
        }

    }

    void ShootUp()//คำสั่งยิงขึ้น
    {
        shoot.Play();//เล่นเสียงยิง
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);//สร้างกระสุนจากตำแหน่งของผู้เล่น
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;//กำหนดความเร็วการเคลื่อนที่ของกระสุน
        Destroy(bullet, 2f);//ทำลายกระสุนเมื่อผ่านไป 2 วินาที
    }
}