## Fluxo de Comunicação

1. **Frontend** faz uma requisição para a API `Meli.Interview.BFF`.
2. **BFF** roteia a requisição para a API correspondente (`Express` ou `DistroCenter`).
3. **API `DistroCenter`**, ao precisar calcular distâncias, faz uma chamada para a **API do Google Maps**.
4. **Google Maps** retorna a distância calculada, e a API `DistroCenter` usa essa informação para determinar o centro de distribuição mais próximo.
5. **Resposta** é enviada de volta ao **BFF**, que a encaminha para o **Frontend**.

## Diagramas de Arquitetura

### Diagrama de arquitetura para o projeto:

    +------------------------------------------------------+
    |                    Camada de Apresentação            |
    |           (Frontend: Aplicações Web ou Mobile)      |
    |                     |                                |
    |                     v                                |
    |             +---------------------+                  |
    |             | Meli.Interview.BFF  |                  |
    |             |  (Backend for       |                  |
    |             |   Frontends)        |                  |
    |             +---------------------+                  |
    |                     |                                |
    |                     v                                |
    |         +---------------------------+                |
    |         |       Microserviços       |                |
    |         |                           |                |
    |         |  +---------------------+  |                |
    |         |  | Meli.Interview.     |  |                |
    |         |  | Express             |  |                |
    |         |  +---------------------+  |                |
    |         |  |  Rotas:             |  |                |
    |         |  |  /api/produto       |  |                |
    |         |  |  /api/pedido        |  |                |
    |         |  +---------------------+  |                |
    |         |                           |                |
    |         |  +---------------------+  |                |
    |         |  | Meli.Interview.     |  |                |
    |         |  | DistroCenter        |  |                |
    |         |  +---------------------+  |                |
    |         |  |  Rotas:             |  |                |
    |         |  |  /api/CentroDistribuicao/...|         |
    |         |  +---------------------+  |                |
    |         |                           |                |
    |         |  +---------------------+  |                |
    |         |  | Google Maps API     |  |                |
    |         |  +---------------------+  |                |
    |         +---------------------------+                |
    +------------------------------------------------------+

# Getting Started
- Para começar com o projeto, siga estas etapas:

1. Clone o Repositório

    - Abra o terminal e execute o seguinte comando para clonar o repositório:

          git clone https://github.com/seu-usuario/seu-repositorio.git
          cd seu-repositorio

2. Abra o Visual Studio

    - Inicie o Visual Studio e abra a solução do projeto (.sln) que você clonou.

3. Configuração do Banco de Dados

    - Certifique-se de que o SQL Server esteja instalado e em execução.
    - Crie um banco de dados para a aplicação e atualize a string de conexão no arquivo appsettings.json de cada aplicação para apontar para o seu banco de dados.

4. Restaurar Dependências

    - No Visual Studio, clique com o botão direito do mouse na solução e selecione "Restaurar Pacotes NuGet" para garantir que todas as dependências estejam instaladas.

5. Configurar o Projeto de Inicialização

    - Clique com o botão direito do mouse na solução e selecione "Propriedades da Solução".
    - Na aba "Startup Project", selecione "Multiple startup projects".
    - Para cada uma das três aplicações (BFF, API de Centros de Distribuição, API de Compras), defina a ação como "Start".

6. Executar as Aplicações

    - Após configurar os projetos de inicialização, pressione F5 ou clique no botão "Iniciar" para executar todas as aplicações simultaneamente.
    - As APIs estarão disponíveis nos seguintes endpoints (ajuste as portas conforme necessário):

          BFF: http://localhost:5000
          API de Centros de Distribuição: http://localhost:5001
          API de Compras (Express): http://localhost:5002

7. Testar as APIs

  - Você pode usar ferramentas como Postman ou cURL para testar os endpoints das APIs. Por exemplo, para processar um pedido, você pode enviar uma requisição POST para o endpoint:

      POST http://localhost:5000/orders

  - Observações
    - Ambiente de Desenvolvimento: Certifique-se de que todas as dependências do projeto estejam instaladas e que o ambiente esteja configurado corretamente.
    - Logs: Verifique os logs de cada aplicação no console do Visual Studio para identificar qualquer problema durante a inicialização.

