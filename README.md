<h3>Projektarbete - Avancerad .NET</h3>

Detta är en REST-API byggd utifrån tre tabeller som skapats genom code-first, och är grunden till ett tidrapporteringssystem. Det kan användas för att t ex ta reda 
på hur många timmar en specifik anställd har jobbat en specifik vecka, eller hämta en lista med alla anställda.

Strukturen bygger på tre interfaces, varav ett huvudsakligt med grundläggande CRUD-metoder, sedan två med extra metoder för att uppfylla kraven på funktionalitet från 
kravspec. Dessa två ärver från det huvudsakliga interfacet. 
De repositories som behöver extra metoder utöver de från huvudinterface ärver från två inteface.



<h4>Optimering</h4>
För att optimera applikationen för backend har följande gjorts:<br>
- Styra inmatning i tabeller med annotationer, och på så sätt minska belastning på databas<br>
- Paginering för att inte hämta all data på en gång, och med valbara mängder, dock ett max per sida<br>
- Alla metoder är asynkrona<br>
- Alla controllers är felhanterade avseende kontakt med databas


<h4>Postman-querys</h4>
<i>- Vi vill kunna få ut en lista med alla anställda i systemet <br></i>
&ensp; GET mot /api/employees/[id]<br>
<i>- Vi vill kunna få ut en lista på alla anställda som jobbar med ett specifikt projekt<br></i>
&ensp; GET mot /api/Projects/listemp/[project]<br>
<i>- Vi vill kunna få ut hur många timmar en specifik anställd jobbat en specifik vecka (ex antal timmar vecka 25)<br></i>
&ensp; GET mot /api/TimeReports/[employeeid]/[week]<br>
<i>- Vi vill kunna lägga till, uppdatera och ta bort anställda.<br></i>
&ensp; POST mot <br>
&ensp; PUT mot <br>
&ensp; DELETE mot <br>
<i>- Vi vill kunna lägga till, uppdatera och ta bort projekt<br></i>
&ensp; POST mot <br>
&ensp; PUT mot <br>
&ensp; DELETE mot <br>
<i>- Vi vill kunna lägga till, uppdatera och ta bort specifika tidsrapporter<br></i>
&ensp; POST mot <br>
&ensp; PUT mot <br>
&ensp; DELETE mot <br>
<i>- Hämta tidsrapporter per sida<br></i>
&ensp; GET mot /api/TimeReports?PageNumber=3&PageSize=20<br>

Utöver detta finns sökning för att hitta anställda via namn.
