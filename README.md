# ViceriProject

#### OBS: Pelo tempo para entregar o desafio, deixei a desejar no conhecimento de Angular. Demorei mais tempo do que eu esperava para fazer o Front do projeto, com isso ficando incompleto. Por esse motivo acabei não adicionando a listagem de superpoderes ao superheroi em "Novo Heroi". Nem a consulta do Heroi por Id no front.

Tecnologias: 
FrontEnd: Angular,
BackEnd: .NET/C#, 
Banco de dados: SQLServer

Fiz o projeto com Front e Back separados de forma que qualquer tecnologia possa consumir as APIS.(React,Angular,ASP.NET...)

## NO PROJETO:
Front: Criei o projeto em Angular, de forma a o clicar em "Novo Heroi" abre-se um box para o preencimento das informações do SuperHeroi.

BackEnd: Crei 3 APIS, todas elas com POST,PUT,GET,DELETE. (API-SuperHerois, API-SuperPoderes, API-HeroisSuperPoderes)

## PARA INICIA-LO:
Em ViceriFront, abra-o(VSCode, VSBasic), no terminal utilize "npm install" para instalar dependencias do projeto. Em seguida "ng server -o" para iniciar o projeto.


Em ViceriBack, abra-o(VSBasic) e utilize a solution TesteViceri-Herois.sln. Entra em appsettings.json e configure a suas ConnectionStrings.


## REQUISITOS:
 
• Cadastro de um novo super-herói - OK

• Listagem dos super-heróis - OK

• Consulta de um super-herói por Id - Apenas API

• Atualização de informações do super-herói por Id - OK

• Exclusão de um super-herói por Id - OK

• Disponibilização da documentação da API utilizando o Swagger - OK (Problemas ao abrir o swagger, utilize "localhost:7182/swagger/index.html"

• Entity Framework para acesso ao banco de dados, tanto para leitura como para gravação - OK
