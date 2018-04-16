# RabbitMQTest
Exemplo de um emulador de navegação de um site que trabalha produzindo conteúdo para o RabbitMQ, e um consumidor para gravar na base SQL a navegação.

Para executar o projeto:

1.Abrir a Solution:
CollectNavigation\CollectNavigation.sln

2. Alterar o connectionstring do banco de dados
CollectNavigation/Presentation.ConsumerNavigation/App.config
CollectNavigation/Presentation.EmulateNavigation/App.config

3. Compilar todos projetos

4. Criar o banco de dados
No projeto CollectNavigation/Repositories.ConsumerNavigation/ executar o commando "Update-Database" no Nuget para gerar a base local.

5. Configurar em ambos webconfig dos projetos as chaves de qual servidor e fila do RabbitMQ:
CollectNavigation/Presentation.ConsumerNavigation/App.config
CollectNavigation/Presentation.EmulateNavigation/App.config

6. Emulador de navegação de um site
cd CollectNavigation/Presentation.EmulateNavigation
dotnet run

7. Consumidor do RabbitMQ
cd CollectNavigation/Presentation.ConsumerNavigation
dotnet run
