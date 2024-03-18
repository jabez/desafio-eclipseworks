# Desafio Técnico Eclipse Works
Esta é a solução para o desafio apresentado pela empresa Eclipse Works.

O desafio é constituido em:
* fase 1 - Desenvolvimento da solução proposta;
* fase 2 - Simulação da interação com o PO visando refinamento para futuras implementações ou melhorias;
* fase 3 - Sugestões técnicas para evolução da aplicação.

### Fase 1 - Desenvolvimento da solução

Como resposta ao desafio foi desenvolvida uma API que permite os usuarios organizar e monitorar suas tarefas diarias.
A API é composta por End-points que permitem a gestão de projeto, tarefas e emissão de relatórios.<br>

![alt](docs/swagger-api.png)

### Padrões e arquitetura
A arquitetura hexagonal foi escolhida para guiar o desenvolvimento da aplicação somado aos preceitos do Clean Code e do SOLID.
A comunicação entre as camadas se dá através de interfaces e injeção de dependência. Foi a adotado a estratégia de middleware para tratar as execeções de maneira global
dando o devido retorno para cada tipo diferente de exception.<BR>
Para atender o requisito de apenas pertimir a execução do relatorio para usuários com função especifica de gerente, foi adotado a estratégia de Filter, assim interceptando a requisição 
e fazendo a validação necessária antes da mesma chegar ao controller.
Cada camada tem seu papel definido:
* *API* -> Camada de interface que expõe endpoints HTTP para comunicação externa com a aplicação.

utilizando a stack .net, docker e o banco de dados SqlServer.

