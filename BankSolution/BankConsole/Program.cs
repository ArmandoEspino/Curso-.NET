﻿using BankConsole;

if(args.Length == 0)
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu(){
    Console.Clear();
    Console.WriteLine("Selecciona una opcion: ");
    Console.WriteLine("1 - Crear nuevo usuario.");
    Console.WriteLine("2 - Eliminar un usuario existente.");
    Console.WriteLine("3 - Salir.");

    int option = 0;

    do{
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un numero (1, 2 o 3).");
        else if (option > 3)
            Console.WriteLine("Debes ingresar un numero valido (1, 2 o 3).");

    }while (option == 0 || option > 3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }

    void CreateUser(){

        Console.Clear();
        int ID;
        decimal balance;
        char userType;
        Console.WriteLine("Ingresa la informacion del usuario");

        do{
            do{
                Console.Write("ID: ");
                ID = int.Parse(Console.ReadLine());

                if(ID <= 0){
                    Console.WriteLine("Escriba un numero positivo");
                    Thread.Sleep(2000);
                }
            }while(ID<0);
            string result = Storage.UserExist(ID);

            if(result.Equals("ID Exist")){
                Console.Write("\nEl ID ya existe");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
                break;
        }while(true);
 
        Console.Write("Nombre: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        do{
            Console.Write("Saldo: ");
            balance = decimal.Parse(Console.ReadLine());
            if(balance < 0){
                Console.Write("Debe ser un numero positivo");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }while(balance < 0);

        do{
        Console.Write("Escribe 'c' si el usuario es un Cliente, 'e' si es un Empleado: ");
        userType = char.Parse(Console.ReadLine());
        if(userType.Equals('c'))
            break;
        if(userType.Equals('e'))
            break;
        
        Console.Write("Debe ingresar 'c' si el usuario es un Cliente, 'e' si es un Empleado");
        Thread.Sleep(2000);
        Console.Clear();

        }while(true);
        User newUser;
        
        if(userType.Equals('c')){

            Console.Write("Regime Fiscal: ");
            char taxRegime = char.Parse(Console.ReadLine());

            newUser = new Client(ID, name, email, balance, taxRegime);

        }else{

            Console.Write("Department: ");
            string department = Console.ReadLine();

            newUser = new Employee(ID, name, email, balance, department);
        }

        Storage.AddUser(newUser);

        Console.WriteLine("Usuario creado.");
        Thread.Sleep(2000);
        ShowMenu();
    }

    void DeleteUser(){

        int ID;
        do{        
        Console.Clear();

        do{
            Console.Write("Ingresa el ID del usuario a eliminar: ");
            ID = int.Parse(Console.ReadLine());
            if(ID < 0){
                Console.Write("Debe ingresar un numero positivo");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }while(ID < 0);

        string result = Storage.DeleteUser(ID);

        if (result.Equals("Success"))
        {
            Console.Write("Usuario eliminado");
            Thread.Sleep(2000);
            ShowMenu();
        }
        }while(true);
    }
}


/*
Client james = new Client(1,"James","james@gmail.com",1000, 'M');
Employee alex = new Employee(2,"Alex","alex@gmail.com",1000, "IT");

Storage.AddUser(james);
Storage.AddUser(alex);
*/