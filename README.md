# Att-göra-lista för DTP15-todolist

PRIO 1 
Ändra metoden för att visa lista, lista allt
- Gör så att kommandot lista bara visar (status)aktiva uppgifter. Implementerad och KLAR!!!
- Gör så  att kommandot lista allt visar alla uppgifter oavsett (status) Implementerad och KLAR!!!

Ändra så att nuvarande lista allt ==> blir beskrivning
- Gör så att anropningen av kommandot lista allt görs med kommandot beskrivning istället 
Implementerad och KLAR!!!

Skapa nya funktioner

- Metod ny = Skapar en ny uppgift, användaren ska ange status, priority, task, taskDescription 
Metoden lägger till ny uppift i todi.lis Implementerad och KLAR!!!

- Metod spara = Anropas detta kommando så sparas nuvarande Att-göra-lista i aktiv .lis fil
OBS. se till att det blir rätt format!!! spara en kopia av todo.lis..Implementerad och KLAR!!!

- Metod ladda = Gör om så att istället för att Att-göra-lista laddas automatiskt, skapa en 
metod som anropas via kommando promten(ladda)!! Implementerad och KLAR!!!

- Metod aktivera, klara, vänta / uppgift =  Gör en metod som kan ändra status på uppgifterna som finns 
i Todo.lis....Implementerad och KLAR!!!

Prio 2

- Metod spara / fil = gör så att man kan spara att-göra-listan genom att anropa spara filnamnet.txt
Implementerad och KLAR!!!

- Metod ladda / fil = som metoden spara / fil fast man laddar upp vald att-göra-lista istället...
Implementerad och KLAR!!!

- Metod lista / klara = lista alla avklarade uppgifter med kommando lista klara....
Implementerad och KLAR!!!

- Metod beskriv / allt = lista alla uppgifter (oavsett status), status, prioritet, namn och beskrivning
Lägg till ett HasArgument "allt" och kalla på printmetod...KLAR!!!

- Refaktorera, repeterar mig nån gång i koden som bör åtgärdas genom en metod istället, kolla även 
igenom koden och dubbelkolla metodnamn och variabelnamn så det följer en given tråd och inte
heter allt från "x" till "min farmors gammla katt()"


Prio 3

Övrig att-göra kommer ligga i en fil som programmet får läsa in genom kommando "ladda"!!!NYI 
