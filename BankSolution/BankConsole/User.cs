namespace BankConsole;

public class User{
    
    private int ID { get; set;}

    private string Name { get; set;}

    private string Email { get; set;}

    private decimal Balance { get; set;}

    private DateTime RegisterDate { get; set;}


    // Constructor

    public User(){
        this.Balance = 2000;
    }

    public User(int ID, string Name, string Email, decimal Balance){
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        this.Balance = Balance;
        this.RegisterDate = DateTime.Now;
    }


    public void setBalance(decimal Balance){
        if(Balance < 0){
            this.Balance = 0;
        }else{
            this.Balance = Balance;
        }
    }

    public string ShowData(){
        return $"\nNombre: {this.Name}\nCorreo: {this.Email}\nSaldo: {this.Balance}\nFecha de registro: {this.RegisterDate}\n";
    }
}