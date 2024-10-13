# Documentação da Arquitetura Meli.Interview.BFF

## Visão Geral do Projeto

- O projeto tem como objetivo desenvolver uma solução que processe pedidos e determine qual centro de distribuição (CD) deve ser utilizado para enviar cada item com base nas informações fornecidas pela API de centros de distribuição. A solução deve ser capaz de lidar com até 100 itens por pedido e fornecer APIs para processar pedidos e consultar pedidos com seus CDs associados.

## Requisitos Funcionais

- Processar pedidos e determinar o CD para cada item.
- Fornecer uma API para processar pedidos e retornar os CDs associados para cada item.
- Fornecer uma API para consultar pedidos e retornar os itens e CDs associados.
- Utilizar a API "Consulta de CDs por Ítem" para auxiliar na determinação do CD para um item.
- Requisitos Não Funcionais

- Escolher uma linguagem de programação preferida.
- Escolher qualquer infraestrutura/ferramenta/framework de preferência.
- Não é necessário desenvolvimento frontend.

## Ficha Técnica

- .NET 8
- SQL Server
- Domain-Driven Design (DDD)
- Inversão de Controle (IoC)
- UnitOfWork
- Arquitetura BFF (Backend For Frontend)
- API de centros de distribuição
- API de compras (Express)

## Introdução

A API Meli.Interview.BFF serve como um ponto de unificação para as funcionalidades das APIs `Meli.Interview.Express` e `Meli.Interview.DistroCenter`. Ela fornece uma interface simplificada para operações de produtos, pedidos e centros de distribuição, otimizando a interação para aplicações frontend.

## Descrição da Arquitetura

### 1. Camada de Apresentação (Frontend)
   - Aplicações Web ou Mobile que consomem a API `Meli.Interview.BFF`.

### 2. Backend for Frontends (BFF) - `Meli.Interview.BFF`
   - **Tecnologia**: .NET 8
   - **Função**: Unifica as funcionalidades das APIs `Express` e `DistroCenter`.
   - **Principais Rotas**:
     - `/api/bff/produto` (GET, POST)
     - `/api/bff/pedido` (POST)
     - `/api/bff/centro-distribuicao/proximo-item` (GET)
     - `/api/bff/centro-distribuicao/por-item/{itemId}` (GET)

### 3. Microserviços

#### a. API de Produtos e Pedidos - `Meli.Interview.Express`
   - **Tecnologia**: .NET 8
   - **Função**: Gerencia operações de produtos e pedidos.
   - **Principais Rotas**:
     - `/api/produto` (GET, POST)
     - `/api/pedido` (POST)

#### b. API de Centros de Distribuição - `Meli.Interview.DistroCenter`
   - **Tecnologia**: .NET 8
   - **Função**: Gerencia informações sobre centros de distribuição.
   - **Principais Rotas**:
     - `/api/CentroDistribuicao/GetCentroDistribuicaoProximoItem` (GET)
     - `/api/CentroDistribuicao/GetCentroDeDistribuicao` (GET)
     - `/api/CentroDistribuicao/GetDistrosCenterByItemCDAsync/{itemId}` (GET)
     - `/api/CentroDistribuicao/GetDistrosCenterByCodigoCD/{IdCD}` (GET)
   - **Integração com Google Maps**:
     - **Objetivo**: Determinar o centro de distribuição mais próximo com base na localização.
     - **Comunicação**: A API `Meli.Interview.DistroCenter` faz chamadas para a API do Google Maps para calcular distâncias e determinar o centro mais próximo.

### 4. Serviços Externos

   - **Google Maps API**
     - **Função**: Fornece serviços de geolocalização e cálculo de distâncias.
     - **Integração**: Utilizada pela API `Meli.Interview.DistroCenter` para determinar a proximidade dos centros de distribuição.

## Fluxo de Comunicação

1. **Frontend** faz uma requisição para a API `Meli.Interview.BFF`.
2. **BFF** roteia a requisição para a API correspondente (`Express` ou `DistroCenter`).
3. **API `DistroCenter`**, ao precisar calcular distâncias, faz uma chamada para a **API do Google Maps**.
4. **Google Maps** retorna a distância calculada, e a API `DistroCenter` usa essa informação para determinar o centro de distribuição mais próximo.
5. **Resposta** é enviada de volta ao **BFF**, que a encaminha para o **Frontend**.

## Diagramas de Arquitetura

### Aqui estão alguns possíveis diagramas de arquitetura para o projeto:

                                      +---------------+
                                      |  API Gateway  |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  BFF Layer     |
                                      |  (Order Processing) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  Application  |
                                      |  Service Layer  |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  Domain Layer  |
                                      |  (Business Logic) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  Infrastructure  |
                                      |  Layer (SQL Server) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  API of Distribution  |
                                      |  Centers (External API) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  API of Purchases    |
                                      |  (Express, External API) |
                                      +---------------+



### Component Diagram
                                      +---------------+
                                      |  OrderProcessor  |
                                      |  (BFF Layer)     |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  OrderService    |
                                      |  (Application Service) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  OrderRepository  |
                                      |  (Infrastructure Layer) |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  DistributionCenterAPI  |
                                      |  (External API)     |
                                      +---------------+
                                             |
                                             |
                                             v
                                      +---------------+
                                      |  PurchaseAPI      |
                                      |  (Express, External API) |
                                      +---------------+

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

