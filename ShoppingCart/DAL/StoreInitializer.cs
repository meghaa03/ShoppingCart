using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryID=1,CategoryName="Electronics"},
                new Category{CategoryID=2,CategoryName="Home"},
                new Category{CategoryID=3,CategoryName="Beauty"},
                new Category{CategoryID=4,CategoryName="Books"},
                new Category{CategoryID=5,CategoryName="Fashion"},
                new Category{CategoryID=6,CategoryName="Grocery"},

            };
            categories.ForEach(s => context.Category.Add(s));
            context.SaveChanges();

            var variants = new List<Variant>
            {
                new Variant{VariantID=1,Color="Red",Size="M"},
                new Variant{VariantID=2,Color="White",Size="XL"},
                new Variant{VariantID=3,Color="-",Size="XL"},
                new Variant{VariantID=4,Color="White",Size="-"},
                new Variant{VariantID=5,Color="Black",Size="M"},
            };
            variants.ForEach(s => context.Variants.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{ProductID=1,Description="HD Ready LED TV ",ProductName="Samsung TV",Price=11499,Quantity=10,ImageUrl="/Images/i1.jpg",VariantID=2,CategoryID=1},
                new Product{ProductID=2,Description="In-Ear Headphones with Mic",ProductName="JBL C100SI",Price=255,Quantity=70,ImageUrl="/Images/i2.jpg",VariantID=2,CategoryID=1},
                new Product{ProductID=3,Description=" High Def Experience with HD resolution",ProductName="Tata Sky HD Set Top Box",Price=3800,Quantity=50,ImageUrl="/Images/i3.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=4,Description="AUX Stereo Splitter Cable ",ProductName="3.5mm Y Splitter ",Price=50,Quantity=1100,ImageUrl="/Images/i4.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=5,Description="16000 mAh",ProductName="Power Bank ",Price=1200,Quantity=100,ImageUrl="/Images/i5.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=6,Description="Aluminium, SAC 175 IY",ProductName="Voltas 1.4 Ton 5 Star",Price=27999,Quantity=1009,ImageUrl="/Images/i6.jpg",VariantID=1, CategoryID=1},
                new Product{ProductID=7,Description="4 Star Direct-Cool Single-Door",ProductName="Whirlpool Refrigerator ",Price=18000,Quantity=500,ImageUrl="/Images/i7.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=8,Description="Fully-Automatic",ProductName="BPL Washing Machine ",Price=16400,Quantity=500,ImageUrl="/Images/i8.jpg",VariantID=1, CategoryID=1},
                new Product{ProductID=9,Description="Electric Storage ",ProductName="A.O. Heater ",Price=6340,Quantity=190,ImageUrl="/Images/i9.jpg",VariantID=1, CategoryID=1},
                new Product{ProductID=10,Description="Point and Shoot",ProductName="Sony Camera",Price=11000,Quantity=500,ImageUrl="/Images/i10.jpg",VariantID=3, CategoryID=1},
                new Product{ProductID=11,Description="SD Class 10",ProductName="Sony Memory Card",Price=1604,Quantity=10,ImageUrl="/Images/i11.jpg",VariantID=1, CategoryID=1},
                new Product{ProductID=12,Description="MP3 Player",ProductName="Philips",Price=2553,Quantity=700,ImageUrl="/Images/i12.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=13,Description="High Resolution Display",ProductName="Kindle Paperwhite",Price=1000,Quantity=190,ImageUrl="/Images/i13.jpg",VariantID=1, CategoryID=1},
                new Product{ProductID=14,Description="All-in-One Printer",ProductName="HP Ink DeskJet",Price=7499,Quantity=5000,ImageUrl="/Images/i14.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=15,Description="Dual Band Router",ProductName="D-Link Wireless",Price=1300,Quantity=500,ImageUrl="/Images/i15.jpg",VariantID=2, CategoryID=1},
                new Product{ProductID=16,Description="Easy to use",ProductName="Kaspersky Internet Security",Price=1590,Quantity=1300,ImageUrl="/Images/i16.jpg",VariantID=4, CategoryID=1},
                new Product{ProductID=17,Description="camera with f1.9",ProductName="Samsung Galaxy On7",Price=11900,Quantity=5000,ImageUrl="/Images/i17.jpg",VariantID=1, CategoryID=1},

                new Product{ProductID=18,Description="H2O Unbreakable",ProductName="Cello Bottle",Price=332,Quantity=500,ImageUrl="/Images/i18.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=19,Description="office Executive Lunch",ProductName="Milton Lunch Box",Price=300,Quantity=50,ImageUrl="/Images/i19.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=20,Description="Royal Oak Geneva",ProductName="Dining Set",Price=23000,Quantity=7300,ImageUrl="/Images/i20.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=21,Description="Mimosaa 100",ProductName="Bombay Dyeing Bedsheet ",Price=549,Quantity=45,ImageUrl="/Images/i21.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=22,Description="40 x 61 cm",ProductName="Recron Pillow",Price=110,Quantity=964,ImageUrl="/Images/i22.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=23,Description="32 cm x 32 cm x 2 cm",ProductName="Ajanta Wall Clock",Price=750,Quantity=987,ImageUrl="/Images/i23.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=24,Description=" Double Bed Foldable ",ProductName="Athenacreations Mosquito Net ",Price=999,Quantity=8787,ImageUrl="/Images/i24.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=25,Description="Double power formula",ProductName="All Out Refill",Price=180,Quantity=34,ImageUrl="/Images/i25.jpg",VariantID =1, CategoryID=2},
                new Product{ProductID=26,Description="100% Cotton",ProductName="Cotton Face Towel",Price=1190,Quantity=567,ImageUrl="/Images/i26.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=27,Description="7W LED",ProductName="Syska SmartLight Bulb",Price=1500,Quantity=456,ImageUrl="/Images/i27.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=28,Description=" with 360° Spin",ProductName="Esquire Spin Mop",Price=500,Quantity=52,ImageUrl="/Images/i28.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=29,Description="Wood Embroidery ",ProductName="Hoop Frame",Price=130,Quantity=52,ImageUrl="/Images/i29.jpg",VariantID=2, CategoryID=2},
                new Product{ProductID=30,Description=" Round Nose",ProductName="Metal Jewelry Making Plier",Price=300,Quantity=5067,ImageUrl="/Images/i30.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=31,Description="Metal Jewelry Findings ",ProductName="Ear Wire Hooks",Price=100,Quantity=111,ImageUrl="/Images/i31.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=32,Description="Cocopeat & Organic Fertilizer",ProductName="MahaGro Potting Mix",Price=11900,Quantity=511,ImageUrl="/Images/i32.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=33,Description="UV Stabilized,",ProductName="Poly Grow Bags",Price=200,Quantity=555,ImageUrl="/Images/i33.jpg",VariantID=1, CategoryID=2},
                new Product{ProductID=34,Description="Require less water source",ProductName="Coco Peat Brick",Price=110,Quantity=577,ImageUrl="/Images/i34.jpg",VariantID=1, CategoryID=2},

                new Product{ProductID=35,Description="Dandruff Protect ",ProductName="Pure Derm Shampoo",Price=110,Quantity=577,ImageUrl="/Images/i35.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=36,Description="Safe for hair",ProductName="Ustraa Hair Wax",Price=240,Quantity=577,ImageUrl="/Images/i36.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=37,Description="600 Peachy-Beachy,",ProductName="Rimmel Lipstick",Price=525,Quantity=577,ImageUrl="/Images/i37.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=38,Description="For Dry Skin",ProductName="Nivea Nourishing Lotion",Price=262,Quantity=577,ImageUrl="/Images/i38.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=39,Description="Coral Craze",ProductName="Maybelline Nail Enamel",Price=110,Quantity=577,ImageUrl="/Images/i39.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=40,Description=" For Men",ProductName="Fogg Impressio Scent",Price=340,Quantity=577,ImageUrl="/Images/i40.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=41,Description="Smooth & Intense",ProductName="L'Oreal Paris Serum",Price=250,Quantity=577,ImageUrl="/Images/i41.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=42,Description="Forest Essentials ",ProductName="Bhringraj Hair Vitalizer",Price=975,Quantity=577,ImageUrl="/Images/i42.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=43,Description="MyGlamm Total Makeover",ProductName=" FF Cream",Price=1510,Quantity=577,ImageUrl="/Images/i43.jpg",VariantID=2, CategoryID=3},
                new Product{ProductID=44,Description="Marble",ProductName="Lakme Face Magic Souffle",Price=1180,Quantity=577,ImageUrl="/Images/i44.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=45,Description="Low in fat",ProductName="Protinex Original",Price=540,Quantity=577,ImageUrl="/Images/i45.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=46,Description="Not from concentrate",ProductName="Apple Cider Vinegar",Price=610,Quantity=577,ImageUrl="/Images/i46.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=47,Description="Banana and Strawberry",ProductName="Nestle Ceregrow NutriPuffs",Price=710,Quantity=577,ImageUrl="/Images/i47.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=48,Description="Free of any artificial flavour",ProductName="NAVAVITA Health Mix",Price=160,Quantity=577,ImageUrl="/Images/i48.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=49,Description=" Adult, Vegetarian",ProductName="Pedigree Dog Food ",Price=520,Quantity=577,ImageUrl="/Images/i49.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=50,Description="Strawberry",ProductName="Chicco Toothpaste",Price=240,Quantity=577,ImageUrl="/Images/i50.jpg",VariantID=1, CategoryID=3},
                new Product{ProductID=51,Description="BG-03 Gluco One ",ProductName="Dr. Morepen Glucometer",Price=1100,Quantity=577,ImageUrl="/Images/i51.jpg",VariantID=2, CategoryID=3},

                new Product{ProductID=52,Description="Indira Paperback – 27 Feb 2018 ",ProductName="Indira",Price=300,Quantity=521,ImageUrl="/Images/i52.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=53,Description="Books on Crime, Thriller and Mystery ",ProductName="The Tandoor Murder",Price=900,Quantity=91,ImageUrl="/Images/i53.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=54,Description="Origin: (Robert Langdon Book 5)",ProductName="Origin",Price=800,Quantity=51,ImageUrl="/Images/i54.jpg",VariantID=5, CategoryID=4},

                new Product{ProductID=55,Description="The Midnight Line: (Jack Reacher 22) Kindle Edition ",ProductName="The Midnight Line",Price=300,Quantity=521,ImageUrl="/Images/i55.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=56,Description="No Middle Name: The Complete Collected Jack Reacher Stories (Jack Reacher Short Stories Book 7) ",ProductName="No Middle Name",Price=9800,Quantity=91,ImageUrl="/Images/i56.jpg",VariantID=5, CategoryID=4},

                new Product{ProductID=57,Description="The Enemy (Jack Reacher, Book 8)",ProductName="The Enemy",Price=8600,Quantity=1,ImageUrl="/Images/i57.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=58,Description="The Last Man: A Novel (A Mitch Rapp Novel Book 11)",ProductName="The Last Man",Price=3000,Quantity=21,ImageUrl="/Images/i58.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=59,Description="Act of Treason (A Mitch Rapp Novel Book 7)",ProductName="Act of Treason",Price=900,Quantity=991,ImageUrl="/Images/i59.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=60,Description="Transfer Of Power (The Mitch Rapp Series Book 1)",ProductName="Transfer Of Power",Price=800,Quantity=51,ImageUrl="/Images/i60.jpg",VariantID=5, CategoryID=4},

                new Product{ProductID=61,Description="Protect and Defend: A Thriller (A Mitch Rapp Novel Book 8)",ProductName="Protect and Defend",Price=800,Quantity=17,ImageUrl="/Images/i61.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=62,Description="Consent to Kill: A Thriller (A Mitch Rapp Novel Book 6)",ProductName="Consent to Kill",Price=9000,Quantity=21,ImageUrl="/Images/i62.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=63,Description="State of the Union: A Thriller (The Scot Harvath Series Book 3) ",ProductName="State of the Union",Price=769,Quantity=1,ImageUrl="/Images/i63.jpg",VariantID=5, CategoryID=4},
                new Product{ProductID=64,Description="The First Commandment: A Thriller (The Scot Harvath Series Book 6)",ProductName="The First Commandment",Price=800,Quantity=51,ImageUrl="/Images/i64.jpg",VariantID=5, CategoryID=4},

                new Product{ProductID=65,Description="Vvoguish Women's Regular Fit Cotton Top",ProductName="Vvoguish Women's Regular Fit Cotton Top",Price=8900,Quantity=17,ImageUrl="/Images/i65.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=66,Description="Veirdo Women's Cotton Tshirts",ProductName="Veirdo Women's Cotton Tshirts",Price=800,Quantity=1,ImageUrl="/Images/i66.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=67,Description="Hypernation Black and Grey Color Shawl Collar T-Shirt for Women",ProductName="Hypernation Black and Grey Color Shawl Collar T-Shirt for Women",Price=800,Quantity=173,ImageUrl="/Images/i67.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=68,Description="Hypernation Purple Color High Neck Cotton T-shirt For Women",ProductName="Hypernation Purple Color High Neck Cotton T-shirt For Women",Price=8400,Quantity=127,ImageUrl="/Images/i68.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=69,Description="Hypernation White Color High Neck Cotton T-shirt",ProductName="Hypernation White Color High Neck Cotton T-shirt",Price=8030,Quantity=127,ImageUrl="/Images/i69.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=70,Description="Trinity Men's Blue Sinker Cotton Lower Trackpants Gym Wear Night Wear Lounge Wear",ProductName="Trinity Men's Blue Sinker Cotton Lower Trackpants Gym Wear Night Wear Lounge Wear",Price=800,Quantity=127,ImageUrl="/Images/i70.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=71,Description="Trinity Men's Blue Sinker Cotton Lower Trackpants Gym Wear Night Wear Lounge Wear",ProductName="Trinity Men's Blue Sinker Cotton Lower Trackpants Gym Wear Night Wear Lounge Wear",Price=800,Quantity=127,ImageUrl="/Images/i71.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=72,Description="Wexford Men's Cotton T-Shirt",ProductName="Wexford Men's Cotton T-Shirt",Price=800,Quantity=127,ImageUrl="/Images/i72.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=73,Description="Little man 100% cotton ethnic kurta style party wear shirt for boys",ProductName="Little man 100% cotton ethnic kurta style party wear shirt for boys",Price=800,Quantity=127,ImageUrl="/Images/i73.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=74,Description="Urbano Fashion Men's Black Slim Fit Stretch Jogger Jeans",ProductName="Urbano Fashion Men's Black Slim Fit Stretch Jogger Jeans",Price=800,Quantity=127,ImageUrl="/Images/i74.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=75,Description="Newport Men's Slim Fit Jeans",ProductName="Newport Men's Slim Fit Jeans",Price=800,Quantity=127,ImageUrl="/Images/i75.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=76,Description="Newport Men's Slim Fit Jeans",ProductName="Newport Men's Slim Fit Jeans",Price=800,Quantity=127,ImageUrl="/Images/i76.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=77,Description="Little man 100% cotton ethnic kurta style party wear shirt for boys",ProductName="Little man 100% cotton ethnic kurta style party wear shirt for boys",Price=800,Quantity=127,ImageUrl="/Images/i77.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=78,Description="Urbano Fashion Men's Black Slim Fit Stretch Jogger Jeans",ProductName="Urbano Fashion Men's Black Slim Fit Stretch Jogger Jeans",Price=800,Quantity=127,ImageUrl="/Images/i78.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=79,Description="Newport Men's Slim Fit Jeans",ProductName="Newport Men's Slim Fit Jeans",Price=800,Quantity=127,ImageUrl="/Images/i79.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=80,Description="Levis Men's Slim Fit Jeans",ProductName="Levis Men's Slim Fit Jeans",Price=800,Quantity=127,ImageUrl="/Images/i80.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=81,Description="Newport Men's Slim Jeans",ProductName="Newport Men's Slim Jeans",Price=800,Quantity=127,ImageUrl="/Images/i81.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=82,Description="Levis Men's Slim Fit Jeans",ProductName="Levis Men's Slim Fit Jeans",Price=800,Quantity=127,ImageUrl="/Images/i82.jpg",VariantID=1, CategoryID=5},
                new Product{ProductID=83,Description="Tata Salt, 1kg",ProductName="Tata Salt, 1kg",Price=800,Quantity=127,ImageUrl="/Images/i83.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=84,Description="Madhur Pure and Hygienic Sugar, 1kg Bag",ProductName="Madhur Pure and Hygienic Sugar, 1kg Bag",Price=800,Quantity=127,ImageUrl="/Images/i84.jpg",VariantID=1, CategoryID=6},

                new Product{ProductID=85,Description="Agro Fresh Premium Ground Nut, 500g",ProductName="Agro Fresh Premium Ground Nut, 500g",Price=800,Quantity=127,ImageUrl="/Images/i85.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=86,Description="Madhur Pure Sugar, 5kg Bag",ProductName="Madhur Pure Sugar, 5kg Bag",Price=800,Quantity=127,ImageUrl="/Images/i86.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=87,Description="Agro Fresh Premium Moong Dal Split, 500g",ProductName="Agro Fresh Premium Moong Dal Split, 500g",Price=800,Quantity=127,ImageUrl="/Images/i87.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=88,Description="Maggi 2-Minutes Noodles Masala, 420g",ProductName="Maggi 2-Minutes Noodles Masala, 420g",Price=800,Quantity=127,ImageUrl="/Images/i88.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=89,Description="Maggi 2-Minutes Noodles Masala, 420g",ProductName="Maggi 2-Minutes Noodles Masala, 420g",Price=800,Quantity=127,ImageUrl="/Images/i89.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=90,Description="Agro Fresh Premium Ground Nut, 500g",ProductName="Agro Fresh Premium Ground Nut, 500g",Price=800,Quantity=127,ImageUrl="/Images/i90.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=91,Description="Agro Fresh Premium Moong Whole, 500g",ProductName="Agro Fresh Premium Moong Whole, 500g",Price=800,Quantity=127,ImageUrl="/Images/i91.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=92,Description="Sunfeast Dark Fantasy Choco Fills, 75g",ProductName="Sunfeast Dark Fantasy Choco Fills, 75g",Price=800,Quantity=127,ImageUrl="/Images/i92.jpg",VariantID=1, CategoryID=6},

                new Product{ProductID=93,Description="Agro Fresh Premium Ground Nut, 500g",ProductName="Agro Fresh Premium Ground Nut, 500g",Price=800,Quantity=127,ImageUrl="/Images/i93.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=94,Description="Agro Fresh Premium Moong Whole, 500g",ProductName="Agro Fresh Premium Moong Whole, 500g",Price=800,Quantity=127,ImageUrl="/Images/i94.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=95,Description="Sunfeast Dark Fantasy Choco Fills, 75g",ProductName="Sunfeast Dark Fantasy Choco Fills, 75g",Price=800,Quantity=127,ImageUrl="/Images/i95.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=96,Description="Agro Fresh Premium Ground Nut, 500g",ProductName="Agro Fresh Premium Ground Nut, 500g",Price=800,Quantity=127,ImageUrl="/Images/i96.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=97,Description="Sunfeast Dark Fantasy Choco Fills, 75g",ProductName="Sunfeast Dark Fantasy Choco Fills, 75g",Price=800,Quantity=127,ImageUrl="/Images/i97.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=98,Description="Madhur Pure Sugar, 5kg Bag",ProductName="Madhur Pure Sugar, 5kg Bag",Price=800,Quantity=127,ImageUrl="/Images/i98.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=99,Description="Agro Fresh Premium Moong Dal Split, 500g",ProductName="Agro Fresh Premium Moong Dal Split, 500g",Price=800,Quantity=127,ImageUrl="/Images/i99.jpg",VariantID=1, CategoryID=6},
                new Product{ProductID=100,Description="Agro Fresh Premium Ground Nut, 500g",ProductName="Agro Fresh Premium Ground Nut, 500g",Price=800,Quantity=127,ImageUrl="/Images/i100.jpg",VariantID=1, CategoryID=6},


            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            
        }
    }
}