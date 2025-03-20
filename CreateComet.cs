using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComet : MonoBehaviour
{
    [SerializeField] float defautltTimer1; //ตัวแปรสำหรับใส่เวลาการเกิดของอุกาบาต
    float Timer1;//ตัวแปรสำหรับเวลา
    public GameObject Comet; //ตัวแปรสำหรับใส่ prefeb อุกาบาต
    GameObject cometClone;//ตัวแปรสำหรับสร้างอุกาบาต

    [SerializeField] float defautltTimer2;//ตัวแปรสำหรับใส่เวลาการเกิดของยานเล็ก
    float Timer2;//ตัวแปรสำหรับเวลา
    public GameObject Scout;//ตัวแปรสำหรับใส่ prefeb ยานเล็ก
    GameObject scoutClone;//ตัวแปรสำหรับสร้างยานเล็ก
    
    Vector3 position;//ตัวแปรตำปหน่ง

    private void Start()
    {
        Timer1 = defautltTimer1;//ตัวแปรเวลา 1 มีค่าเท่ากับค่าเวลาเกิดของอุกาบาต
        Timer2 = defautltTimer2;//ตัวแปรเวลา 2 มีค่าเท่ากับค่าเวลาเกิดของยานเล็ก
    }

    void Update()
    {
        Timer1 -= Time.deltaTime;//ตัวแปรเวลา 1 นับถอยหลัง
        if (Timer1 <= 0)//ถ้าตัวแปรเวลา 1 น้อยกว่าหรือเท่ากับ 0
        {
            position = new Vector3((Random.Range(-9,9)),8,0);//สุ่มตำแหน่งในแกน x ตั้งแต่ -9 ถึง 9 แกน y 8 แกน z 0
            cometClone = Instantiate(Comet, position, transform.rotation)as GameObject;//สร้างอุกาบาตโดยอ้างอิงตำแหน่งของ position ในฐานะเกม object
            Timer1 = defautltTimer1;//รีเซ็ทเวลา
            Destroy(cometClone, 5f);//ทำลายวัตถุเมื่อวาลาผ่านไป 5 วินาที
        }
        
        Timer2 -= Time.deltaTime;
        if (Timer2 <= 0)
        {
            position = new Vector3((Random.Range(-8,8)),8,0);//สุ่มตำแหน่งในแกน x ตั้งแต่ -9 ถึง 9 แกน y 8 แกน z 0
            scoutClone = Instantiate(Scout, position, transform.rotation)as GameObject;//สร้างยานเล็กโดยอ้างอิงตำแหน่งของ position ในฐานะเกม object
            Timer2 = defautltTimer2;//รีเซ็ทเวลา
            Destroy(scoutClone, 5f);//ทำลายวัตถุเมื่อวาลาผ่านไป 5 วินาที
        }
    }
}
