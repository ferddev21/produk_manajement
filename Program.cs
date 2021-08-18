using System;
using System.Collections.Generic;

namespace produk_manajement
{
    class Program
    {
        public static List<string> products = new List<string>();
        public static List<Users> ListOfUsers = new List<Users>()
        {
            new Users() {username ="ferdian", password="1234"}
        };

        public static List<string> SessionUser = new List<string>();

        static void Main(string[] args)
        {
            AuthLogin();
            TestAddProduct();
            ViewMenu();
        }
        static void ViewMenu()
        {
            bool check = true;
            while (check)
            {
                ViewProduct();
                System.Console.WriteLine(" Menu : ");
                System.Console.WriteLine("1. Tambah Produk ");
                System.Console.WriteLine("2. Edit Produk ");
                System.Console.WriteLine("3. Hapus Produk ");
                System.Console.WriteLine("q. Keluar ");
                System.Console.WriteLine("Pilih menu : ");
                String item = System.Console.ReadLine();
                Console.Clear();
                switch (item)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        UpdateProduct();
                        break;

                    case "3":
                        DeleteProduct();
                        break;
                    case "q":
                        check = false;
                        break;
                    default:
                        check = true;
                        break;
                }

            }
        }


        static void TestAddProduct()
        {
            products.Add("produk A");
            products.Add("produk B");
            products.Add("produk C");
        }

        // Menampilan view product
        static void ViewProduct()
        {
            System.Console.WriteLine("-------------");
            for (int i = 0; i < products.Count; i++)
            {
                var item = products[i];
                var no = i + 1;

                if (item != null)
                {
                    System.Console.WriteLine(no + ". " + item);
                }
            }

            if (products.Count == 0)
            {
                System.Console.WriteLine("tidak ada data!");
            }
            System.Console.WriteLine("-------------");
        }

        // Menambahkan product
        static void AddProduct()
        {
            string check = "y";
            while (check == "y" || check == "Y")
            {
                ViewProduct();
                System.Console.Write("masukkan produk :");
                String item = System.Console.ReadLine();
                products.Add(item);
                Console.Clear();

                ViewProduct();
                System.Console.Write("Mau tambah produk lagi, klik y ? ");
                check = System.Console.ReadLine();
                Console.Clear();

            };
        }

        // Mengupdate product
        static void UpdateProduct()
        {

            string check = "y";
            while (check == "y" || check == "Y")
            {
                ViewProduct();
                System.Console.Write("masukkan nomor produk :");
                string nomor = Console.ReadLine();
                char firstChar = nomor[0];
                bool isNumber = Char.IsDigit(firstChar);
                if (isNumber)
                {
                    int index = Convert.ToInt32(isNumber) - 1;
                    Console.Clear();

                    System.Console.WriteLine(nomor + ". " + products[index]);

                    System.Console.WriteLine("-------------");
                    System.Console.Write("Nama produk : ");
                    String updateItem = System.Console.ReadLine();

                    //update produk
                    products[index] = updateItem;

                    Console.Clear();
                    System.Console.WriteLine("Success Update! ");

                    ViewProduct();
                    System.Console.Write("Mau mengedit produk lagi, klik y ? ");
                    check = System.Console.ReadLine();
                }
                else
                {
                    check = "n";
                }
                Console.Clear();
            };
        }

        // Menghapus Product
        static void DeleteProduct()
        {
            string check = "y";
            while (check == "y" || check == "Y")
            {
                ViewProduct();
                System.Console.Write("masukkan nomor produk yang ingin dihapus :");
                string nomor = Console.ReadLine();
                char firstChar = nomor[0];
                bool isNumber = Char.IsDigit(firstChar);
                if (isNumber)
                {
                    int index = Convert.ToInt32(isNumber) - 1;
                    Console.Clear();

                    System.Console.WriteLine(nomor + ". " + products[index]);

                    System.Console.WriteLine("-------------");
                    System.Console.Write("Anda Yakin, klik Y ? ");

                    check = System.Console.ReadLine();

                    if (check == "y" || check == "Y")
                    {
                        //delete produk
                        products.Remove(products[index]);

                        Console.Clear();
                        System.Console.WriteLine("Success Delete! ");

                        ViewProduct();
                        System.Console.WriteLine("");
                        System.Console.Write("Mau menghapus produk lagi, klik y ? ");
                        check = System.Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        check = "n";
                    }
                }
                else
                {
                    check = "n";
                }
                Console.Clear();
            };
        }

        static void AuthLogin()
        {
            var checkLogin = false;

            while (!checkLogin)
            {
                System.Console.Write("Username : ");
                String usernameInput = System.Console.ReadLine();

                System.Console.Write("Password : ");
                String passwordInput = System.Console.ReadLine();
                checkLogin = CheckLogin(usernameInput, passwordInput);

                Console.Clear();
            }
            System.Console.WriteLine("Sukses Login! ");
        }

        static Boolean CheckLogin(string usernameInput, string passwordInput)
        {
            var status = false;
            //cari user pada list
            for (int i = 0; i < ListOfUsers.Count; i++)
            {
                var user = ListOfUsers[i];
                if (user.username == usernameInput && user.password == passwordInput)
                {
                    status = true;
                    break;
                }
                status = false;
            }

            return status;
        }
    }

    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
