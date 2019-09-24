using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace _2019CSharp
{
    public class FoodDataSource
    {
        bool isLoaded = false;

        public List<Food> lstFood;

        public void Load()
        {
            if (isLoaded) return;

            lstFood = new List<Food>()
            {
                new Food() { Name="차돌 떡볶이", Price=17500, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main.png"},
                new Food() { Name="통닭 떡볶이", Price=18500, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main2.png" },
                new Food() { Name="빨간크림 떡볶이", Price=14000, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main3.png" },
                new Food() { Name="깻잎순대 떡볶이", Price=16500, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main4.png" },
                new Food() { Name="치믈렛 떡볶이", Price=15000, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main5.png" },
                new Food() { Name="통큰오짱 떡볶이", Price=17500, Count=0, Category=Category.eCategory.단품, ImagePath="/Assets/main6.png" },
                new Food() { Name="청년돈까스", Price=7500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side2.png" },
                new Food() { Name="꼬치어묵탕", Price=13000, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side3.png" },
                new Food() { Name="엄마빠다밥", Price=2000, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side10.png" },
                new Food() { Name="불향가득차돌덮밥", Price=7500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side1.png" },
                new Food() { Name="매콤오징어덮밥", Price=6500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side11.png" },
                new Food() { Name="바삭새우덮밥", Price=6500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side12.png" },
                new Food() { Name="치낙볶음밥", Price=6500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side13.png" },
                new Food() { Name="치킨빠다밥", Price=6500, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side14.png" },
                new Food() { Name="매콤차돌덮밥", Price=7000, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side15.png" },
                new Food() { Name="찰 순대", Price=3000, Count=0, Category=Category.eCategory.식사, ImagePath="/Assets/side4.png" },
                new Food() { Name="아메리카노", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img1.png" },
                new Food() { Name="카페라떼", Price=3000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img3.png" },
                new Food() { Name="바닐라라떼", Price=3000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img2.png" },
                //new Food() { Name="카라멜 마끼아또", Price=4500, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img4.png" },
                new Food() { Name="아이스티", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img4.png" },
                new Food() { Name="에이드", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img5.png" },
                new Food() { Name="에이드1人", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img6.png" },
                new Food() { Name="핫초코 / 아이스초코", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img7.png" },
                new Food() { Name="미수까루", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img8.png" },
                new Food() { Name="단호박식혜", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img11.png" },
                new Food() { Name="쿨다방", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img9.png" },
                new Food() { Name="탄산", Price=2000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/drink_img10.png" },
                new Food() { Name="크림생맥주", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img1.png" },
                new Food() { Name="자몽비어", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img2.png" },
                new Food() { Name="라임비어", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img3.png" },
                new Food() { Name="청포도비어", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img4.png" },
                new Food() { Name="소주", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img5.png" },
                new Food() { Name="맥주", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img6.png" },
                new Food() { Name="청하", Price=4000, Count=0, Category=Category.eCategory.음료, ImagePath="/Assets/ach_img7.png" },
            };

            isLoaded = true;
        }
    }
}
