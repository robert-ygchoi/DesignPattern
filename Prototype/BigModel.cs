using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Prototye패턴을 구현할 때 고려해야할 것.
/// 1. 상속에서의 문제
///     부모에서 private으로 선언되어 있는 멤버변수를 자식에서 DeepCopy 할 수 없다.
///     1. 복사 생성자를 protected로 선언한다.
///     2. Clone 함수에서 복사 생성자를 호출하고 추상화 한다.
///     3. 자식에서 똑같이 복사 생성자를 만들고 ICloneable 확장하고 부모의 Clone Method를 Override 한다. 
/// 2. 멤버 추가로 인한 Clone Method 관리

namespace Prototype
{
    internal class BaseBigModel : ICloneable
    {
        internal string Foo { get; private set; }
        internal string Boo { get; private set; }        
        /// DeepCopy에 문제가 되는 멤버
        private string Doo { get; set; }

        internal BaseBigModel(string foo, string boo, string doo)
        {
            Foo = foo;
            Boo = boo;
            Doo = doo;
        }

        /// <summary>
        /// 복사 생성자
        /// </summary>
        /// <param name="baseBigModel">복사할 객체</param>
        protected BaseBigModel(BaseBigModel baseBigModel)
        {
            Foo = baseBigModel.Foo;
            Boo = baseBigModel.Boo;
            Doo = baseBigModel.Doo;
        }

        /// <summary>
        /// ICloneable 정의, 추상화
        /// </summary>
        /// <returns>DeepCopy 객체</returns>
        public virtual object Clone()
        {
            /// 복사 생성자 호출
            return new BaseBigModel(this);
        }

        public override string ToString() => $"{Foo}, {Boo}, {Doo}";
    }

    /// <summary>
    /// 부모 상속, ICloneable 확장
    /// </summary>
    internal class ChildBigModel : BaseBigModel, ICloneable
    {
        internal string Zoo { get; private set; }

        /// <summary>
        /// 복사 생성자
        /// </summary>
        /// <param name="childBigModel">복사할 객체</param>
        protected ChildBigModel(ChildBigModel childBigModel) : base(childBigModel)
        {
            Zoo = childBigModel.Zoo;
        }

        public ChildBigModel(string foo, string boo, string doo, string zoo) : base(foo, boo, doo)
        {
            Zoo = zoo;
        }

        /// <summary>
        /// ICloneable 재정의
        /// </summary>
        /// <returns>DeepCopy 객체</returns>
        public override object Clone()
        {
            /// 복사 생성자 호출
            return new ChildBigModel(this);
        }

        public override string ToString() => $"{base.ToString()}, {Zoo}";
    }
}

