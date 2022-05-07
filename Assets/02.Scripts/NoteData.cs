using UnityEngine;

/// <summary>
///  특정 시간과 키에 대한 노트 데이터를 저장하기위한 클래스
/// </summary>

// Tip
// C#에는 값 형식과 참조 형식이 있는데,
// 깂형식은 말그대로 값을 읽고 쓰는 형식,
// 값형식의 종류 : 일반적인 데이터 타입들 ( int, flaot, double, enum, structure 등... )
// 참조형식은 주소를 참조해서 해당 주소의 값을 읽고 쓰는 형식
// 참조형식의 종류 : 클래스, 인터페이스, 델리게이트
// 참조형식을은 기본적으로 Serialize 가 안됨 (주소값을 그대로 Serialize 하는것은 의미가 없음)
// 하지만 Serialzable 속성을 주면
// 참조 형식을 Serialize 시도할때 해당 주소의 합영역에 있는 값들을 읽어옴.

[System.Serializable] // 해당 클래스 타입의 오브젝트가 Serialze 가능하도록 해주는 속성
public class NoteData
{
    public float time; // 뮤직비디오와 
    public KeyCode keyCode; //
}
