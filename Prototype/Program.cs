using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseBigModel baseBigModel = new BaseBigModel("안녕하세요", "반갑습니다", "또 만나요");
            Console.WriteLine("==============base==============");
            Console.WriteLine(baseBigModel);

            BaseBigModel newBaseBigModel = baseBigModel.Clone() as BaseBigModel;
            Console.WriteLine($"clone: {newBaseBigModel}");

            Console.WriteLine($"ReferenceEqulas: {ReferenceEquals(baseBigModel, newBaseBigModel)}");
            

            Console.WriteLine("==============child==============");
            ChildBigModel childBigModel = new ChildBigModel("하하", "호호", "히히", "헤헤");
            Console.WriteLine(childBigModel);

            ChildBigModel newCHildBigModel = childBigModel.Clone() as ChildBigModel;
            Console.WriteLine($"clone: {newCHildBigModel}");

            Console.WriteLine($"ReferenceEqulas: {ReferenceEquals(childBigModel, newCHildBigModel)}");

            Console.ReadLine();
        }
    }
}
