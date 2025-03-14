// See https://aka.ms/new-console-template for more information 
// hien thi du lieu

/*Console.WriteLine("Hello, World!");
Console.Write(6);
int a=9;
Console.WriteLine("a="+a);
int b=3;
Console.WriteLine("{0}+{1}={2}",a,b,a+b);
*/


//nhap du lieu
/*Console.Write("nhap du lieu:");
string z= Console.ReadLine();
Console.WriteLine("du lieu vua nhap la:"+z);*/


//khai bao bien
// data type+name+ = value;
//khai bao hang
// const data type+name+ = value;

//chuyen doi du lieu 
// kieudl + .parse +kieu can doi
//vi du sting a = 123; int b = int.parse(a);
//      int.TryParse(bien cũ muon doi,out(bien mới muon doi kieu));

// toan tu
/*
Console.Write("nhap so a:");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("nhap so b:");
int b = Convert.ToInt32(Console.ReadLine());
int c = a + b;
Console.WriteLine("tong cua a va b la:" + c);   
int d = a - b;
Console.WriteLine("hieu cua a va b la:" + d);
int e = a * b;
Console.WriteLine("tich cua a va b la:" + e);
int f = a / b;
Console.WriteLine("thuong cua a va b la:" + f);
int g = a % b;
Console.WriteLine("phan du cua a va b la:" + g);
*/
//if else
/*Console.Write("nhap so a:");
int a = Convert.ToInt32(Console.ReadLine());
if (a % 2 == 0)
{
    Console.WriteLine("so chan");
}
else
{
    Console.WriteLine("so le");
}
//if else if
Console.Write("nhap so a:");
int ab = Convert.ToInt32(Console.ReadLine());
if (ab > 0)
{
    Console.WriteLine("so duong");
}
else if (ab < 0)
{
    Console.WriteLine("so am");
}
else
{
    Console.WriteLine("so 0");
}
//switch case
Console.Write("nhap so a:");
int b = Convert.ToInt32(Console.ReadLine());
switch (b)
{
    case 1:
        Console.WriteLine("so 1");
        break;
    case 2:
        Console.WriteLine("so 2");
        break;
    case 3:
        Console.WriteLine("so 3");
        break;
    default:
        Console.WriteLine("so khac");
        break;
}
//vong lap for
Console.Write("nhap so a:");    
int v = Convert.ToInt32(Console.ReadLine());
for (int j = 0; j < a; j++)
{
    Console.WriteLine("gia tri cua j la:" + j);
}
//vong lap while
Console.Write("nhap so a:");
int c = Convert.ToInt32(Console.ReadLine());
int i = 0;
while (i < c)
{
    Console.WriteLine("gia tri cua i la:" + i);
    i++;
}
//vong lap do while
Console.Write("nhap so a:");
int d = Convert.ToInt32(Console.ReadLine());
int k = 0;
do
{
    Console.WriteLine("gia tri cua k la:" + k);
    k++;
} while (k < d);*/
// break continue
/*for (int l = 0; l < 10; l++)
{
    if (l == 5)
    {
        break;
    }
    Console.WriteLine("gia tri cua l la:" + l);
}
for (int m = 0; m < 10; m++)
{
    if (m == 5)
    {
        continue;
    }
    Console.WriteLine("gia tri cua m la:" + m);
}*/
//mang
/*int[] arr = new int[5];
arr[0] = 1;
arr[1] = 2;
arr[2] = 3;
arr[3] = 4;
arr[4] = 5;
for (int n = 0; n < arr.Length; n++)
{
    Console.WriteLine("gia tri cua phan tu thu " + n + " la:" + arr[n]);
}
//mang 2 chieu
int[,] arr2 = new int[2, 3];
arr2[0, 0] = 1;
arr2[0, 1] = 2;
arr2[0, 2] = 3;
arr2[1, 0] = 4;
arr2[1, 1] = 5;
arr2[1, 2] = 6;
for (int o = 0; o < 2; o++)
{
    for (int p = 0; p < 3; p++)
    {
        Console.WriteLine("gia tri cua phan tu thu [" + o + "," + p + "] la:" + arr2[o, p]);
    }
}
*/
using NewApp.Models;

namespace NewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.EnterData();
            person.DisplayData();
        }
    }
}