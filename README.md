# RabbitMQTest
Exemplo de um emulador de navegação de um site que trabalha produzindo conteúdo para o RabbitMQ, e um consumidor para gravar na base SQL a navegação.

Para executar o projeto:

Configurar em ambos webconfig dos projetos as chaves de qual servidor e fila do RabbitMQ:
CollectNavigation\Presentation.ConsumerNavigation\App.config
CollectNavigation\Presentation.EmulateNavigation\App.config

Emulador de navegação de um site
cd CollectNavigation\Presentation.EmulateNavigation
dotnet run

Consumidor do RabbitMQ
cd CollectNavigation\Presentation.ConsumerNavigation
dotnet run
