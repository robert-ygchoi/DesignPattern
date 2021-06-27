using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// 냉장고 문의 역할을 전략패턴으로 구현
//
namespace Strategy
{
    //
    // 냉장고 문의 행위
    //
    internal interface IRefrigeratorDoor
    {
        void Work();
    }
    
    //
    // 냉장고 부모 클래스
    //
    internal abstract class Refrigerator
    {
        protected IRefrigeratorDoor[] Doors { get; private set; }
        protected abstract int DoorCount { get; }
        protected abstract string GetDoorLocation(int doorIdx);

        public void SetDoor(params IRefrigeratorDoor[] refrigeratorDoor)
        {
            if(DoorCount != refrigeratorDoor.Length)
            {
                Console.WriteLine("문의 갯수가 맞지 않습니다.");
                return;
            }

            Doors = refrigeratorDoor;
        }

        public void Works()
        {
            if(Doors is null)
            {
                Console.WriteLine("문을 아직 달지 않았습니다.");
                return;
            }

            for (int idx = 0; idx < Doors.Length; idx++)
            {
                Console.Write($"{GetDoorLocation(idx)}문 ");
                Doors[idx].Work();
            }
        }
    }

    //
    // 문 네 개 냉장고
    //
    internal class FourDoorRefrigerator : Refrigerator
    {
        protected override int DoorCount => 4;

        protected override string GetDoorLocation(int doorIdx) => doorIdx switch { 0 => "왼쪽 윗", 1 => "오른쪽 윗", 2 => "왼쪽 아랫", 3 => "오른쪽 아랫", _ => throw new ArgumentOutOfRangeException("문은 총 네짝입니다.") };
    }

    //
    // 문 두 개 냉장고
    //
    internal class TwoDoorRefrigerator : Refrigerator
    {
        protected override int DoorCount => 2;

        protected override string GetDoorLocation(int doorIdx) => doorIdx switch { 0 => "윗", 1 => "아랫", _ => throw new ArgumentOutOfRangeException("문은 총 네짝입니다.") };
    }

    //
    // 행위를 클래스화 한다.
    //
    internal class KimchiDoor : IRefrigeratorDoor
    {
        public void Work() => Console.WriteLine("잘익는 김치냉장고문");
    }
    internal class FridgeDoor : IRefrigeratorDoor
    {
        public void Work() => Console.WriteLine("너무 시원한 냉장고문");
    }
    internal class FreezeDoor : IRefrigeratorDoor
    {
        public void Work() => Console.WriteLine("꽁꽁 어는 냉동고문");
    }
}
