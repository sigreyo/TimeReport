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
