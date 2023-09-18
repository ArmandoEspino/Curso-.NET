Console.Clear();
bool shutdown = false;
int opcion = 0;
int retiros = 0;
int fondos = 50000;
int a = 0;
int[] billetes = new int[10];
int[] monedas = new int[10];
int[] CantidadRetiros = new int[10];
while(shutdown == false)    
{
    Console.WriteLine("Hello, Welcome to Bancamex!");
    Console.ReadKey();
    Console.Clear();
    while(opcion != 1 && opcion != 2){
        Console.WriteLine("---------- Bancamex ---------- ");
        Console.WriteLine("1) Ingresar la cantidad de retiros hechos por los usuarios.\n");
        Console.WriteLine("2) Revisar la cantidad entregada de billetes y monedas.");
        Console.WriteLine("\n\nIngrese la opcion: ");
        opcion = int.Parse(Console.ReadLine());
        Console.Clear();
    };
    Console.WriteLine(opcion);
    switch(opcion){
        case 1:
            Console.Clear();
            while(retiros < 1 || retiros > 10){
                Console.WriteLine("Cuantos retiros se hicieron? (Max. 10)");
                retiros = int.Parse(Console.ReadLine());
            };

            for(int i = 0; i < retiros; i++){
                Console.WriteLine(fondos);
                Console.WriteLine($"\nIngrese la cantidad del retiro #{i+1}: ");
                CantidadRetiros[i] = int.Parse(Console.ReadLine());

                // Operaciones con billetes y monedas
                int billete500 = 0;
                int billete200 = 0;
                int billete100 = 0;
                int billete50 = 0;
                int billete20 = 0;
                int moneda10 = 0;
                int moneda5 = 0;
                int moneda1 = 0;
                int dinero = 0;

                dinero = CantidadRetiros[i];
                fondos = fondos - dinero;

                if(fondos < 0){
                    Console.Clear();
                    Console.WriteLine("No cuenta con dinero suficiente O_o");
                    Console.ReadKey();
                    break;
                }

                if(dinero/500 > 0){
                    billete500 = dinero / 500;
                    dinero = dinero % 500;
                }
                if(dinero/200 > 0){
                    billete200 = dinero / 200;
                    dinero = dinero % 200;
                }
                if(dinero/100 > 0){
                    billete100 = dinero / 100;
                    dinero  = dinero % 100;
                }
                if(dinero/50 > 0){
                    billete50 = dinero/50;
                    dinero = dinero % 50;
                }
                if(dinero/20 > 0){
                    billete20 = dinero/20;
                    dinero = dinero % 20;
                }
                if(dinero/10 > 0){
                    moneda10 = dinero / 10;
                    dinero = dinero % 10;
                }
                if(dinero/5 > 0){
                    moneda5 = dinero / 5;
                    dinero = dinero % 5;
                }
                moneda1 = dinero;
                billetes[i] = billete500 + billete200 + billete100 + billete50 + billete20;
                monedas[i] = moneda10 + moneda5 + moneda1;
            };
            a += 1;
        break;

        case 2:
            Console.Clear();
            if(a > 0){
                for(int i = 0; i < retiros; i++){
                    Console.WriteLine($"Retiro #{i+1}: ");
                    Console.WriteLine($"Dinero: {CantidadRetiros[i]} \n");
                    Console.WriteLine($"Billetes entregados:  {billetes[i]} ");
                    Console.WriteLine($"Monedas entregadas:  {monedas[i]} \n\n");
                }
            }else{
                Console.WriteLine("Aun no se han hecho retiros");
            }
        break;
    }
    opcion = 0;
    Console.ReadKey();
    Console.Clear();

    // Si se desea ciclar el programa quitar la siguiente instruccion.
    //shutdown = true;
}



        /*if(opcion < 1 || opcion > 2){
            Console.WriteLine("\n\nError al capturar, intente de nuevo");
            Console.ReadKey();
        }
                            if(fondos == 0){
                        Console.WriteLine("Usted no cuenta con dinero suficiente  O_o");
                        break;
                    }
        Console.Clear();*/