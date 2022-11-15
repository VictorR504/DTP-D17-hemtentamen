# Att-göra-lista för DTP15-todolist

PRIO 1 
Ändra metoden för att visa lista, lista allt
- Gör så att kommandot lista bara visar (status)aktiva uppgifter. KLAR!!!
- Gör så  att kommandot lista allt visar alla uppgifter oavsett (status) KLAR!!!

Ändra så att nuvarande lista allt ==> blir beskrivning
- Gör så att anropningen av kommandot lista allt görs med kommandot beskrivning istället KLAR!!!

Skapa nya funktioner

- Metod ny = Skapar en ny uppgift, användaren ska ange status, priority, task, taskDescription 
Metoden lägger till ny uppift i todi.lis KLAR!!!

- Metod spara = Anropas detta kommando så sparas nuvarande Att-göra-lista i aktiv .lis fil
OBS. se till att det blir rätt format!!! spara en kopia av todo.lis..KLAR!!!!

- Metod ladda = Gör om så att istället för att Att-göra-lista laddas automatiskt, skapa en 
metod som anropas via kommando promten(ladda)!!  KLAR!!!!

- Metod aktivera, klara, vänta / uppgift =  Gör en metod som kan ändra status på uppgifterna som finns 
i Todo.lis....KLAR!!!!

Prio 2

- Metod ny / uppgift = skapa en ny uppgift med namnet /uppgift/ NYI

- Metod redigera / uppgift = redigera en uppgift med namnet /uppgift/ NYI

- Metod kopiera / uppgift = redigera en uppgift med namnet /uppgift/ till namnet NYI

- Metod beskriv / allt = lista alla uppgifter (oavsett status), status, prioritet, namn och beskrivning
Lägg till ett HasArgument "allt" och kalla på printmetod...KLAR!!!
