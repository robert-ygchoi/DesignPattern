using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 냉장고 문의 기능들을 생성한다.
            // 1. 냉장고 문
            // 2. 냉동고 문
            // 3. 김치냉장고 문
            // ※ 테스트 코드이고 각 문 클래스 안에는 필드나 프로퍼티가 없으므로 재사용함.
            //

            FridgeDoor fridgeDoor = new FridgeDoor();
            FreezeDoor freezeDoor = new FreezeDoor();
            KimchiDoor kimchiDoor = new KimchiDoor();

            //
            // 1 문 두 개 냉장고를 생성한다.
            //  1-1 위에는 냉동고, 아래는 냉장고로 만든다.
            //  1-2 위에는 김치냉장고, 아래는 냉동고로 만든다.
            //

            TwoDoorRefrigerator twoDoorRefrigerator = new TwoDoorRefrigerator();
            twoDoorRefrigerator.SetDoor(freezeDoor, fridgeDoor);
            twoDoorRefrigerator.Works();

            twoDoorRefrigerator.SetDoor(kimchiDoor, freezeDoor);
            twoDoorRefrigerator.Works();

            Console.WriteLine("=========");
            //
            // 2 문 네 개 냉장고를 생성한다.
            //   문 생성 순서는 다음과 같다.
            //   왼쪽 위, 오른쪽 위, 왼쪽 아래, 오른쪽 아래
            // 2-1 냉장고, 냉장고, 냉동고, 냉동고로 만든다.
            // 2-2 냉장고, 냉장고, 김치냉장고, 냉동고로 만든다.
            //

            FourDoorRefrigerator fourDoorRefrigerator = new FourDoorRefrigerator();
            fourDoorRefrigerator.SetDoor(fridgeDoor, fridgeDoor, freezeDoor, freezeDoor);
            fourDoorRefrigerator.Works();

            fourDoorRefrigerator.SetDoor(fridgeDoor, fridgeDoor, kimchiDoor, freezeDoor);
            fourDoorRefrigerator.Works();
        }
    }
}
