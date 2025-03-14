namespace NewApp.Models
{
    public class Person
    {
       public string FullName { get; set; }

      public string Address { get; set; }

       public void EnterData(){
            System.Console.WriteLine("Enter Full Name: ");
            FullName = System.Console.ReadLine();
            System.Console.WriteLine("Enter Address: ");
            Address = System.Console.ReadLine();
       }
       public void DisplayData(){
            System.Console.WriteLine("Full Name: " + FullName);
            System.Console.WriteLine("Address: " + Address);
       }
    }
}